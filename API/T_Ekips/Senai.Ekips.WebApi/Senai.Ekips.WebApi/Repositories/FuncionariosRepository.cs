using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionariosRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=T_Ekips;User Id=sa;Pwd=132";


        public List<Funcionario> Listar()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            string Query = "select * from Filmes";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Funcionario funcionario = new Funcionario
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Cpf = sdr["Cpf"].ToString(),
                            DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                            Salario = Convert.ToInt32(sdr["Salario"]),
                            IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                            IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                            IdUsuario = Convert.ToInt32(sdr["IdUsuario"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        internal static void Cadastrar(Departamento departamento)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionario.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario FuncionarioBuscado = ctx.Funcionario.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioBuscado.Nome = funcionario.Nome;
                ctx.Funcionario.Update(FuncionarioBuscado);
                ctx.SaveChanges();
            }
        }
    }
}

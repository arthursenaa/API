using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        //private string StringConexao = "Data Source=.\\MSSQLSERVER;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";
        //private string StringConexao = "Data Source=localhost;Initial Catalog=T_Peoples;Integrated Security=true;";
        private string StringConexao = "Data Source=.\\SQLEXPRESS;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";
        //private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";
        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            //sqlConnection para chamar o Banco
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Query para 'comando' que eu quero fazer no banco
                string Query = "select * from Funcionarios";

                //Con.Open para conectar com o banco
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }


        public FuncionariosDomain BuscarPorId(int id)
        {

            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Execute FuncionariosPorId  @Id";

                con.Open();

                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FuncionariosDomain funcionario = new FuncionariosDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionariosDomain funcionarioDomain)
        {
            string Query = "Insert into Funcionarios (Nome,Sobrenome) values('@Nome' , '@Sobrenome')";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string Query = "Delete from Funcionarios where IdFuncionario = @Id";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(FuncionariosDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome ,Sobrenome = @Sobrenome WHERE IdFuncionario = @Id";
            // estabelecer a conexao
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // comando
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionario);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                // abre a conexao
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

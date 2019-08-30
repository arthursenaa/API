using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentosRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=T_Ekips;User Id=sa;Pwd=132";


        public List<Departamento> ListarDepartamentos()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.ToList();
            }
        }

        

        public Departamento ListarPorId(int Id)
        {

            string Query = "Select * from Departamento where IdDepartamento = @Id ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            Departamento Departamento = new Departamento()
                            {
                                IdDepartamento = Convert.ToInt32(sdr["IdDepartamento"]),
                                Departamento1 = sdr["Departamento"].ToString()
                            };

                            return Departamento;
                        }
                    }
                    return null;
                }


            }
        }
        public void Cadastrar(Departamento departamento)
        {
             using (EkipsContext ctx = new EkipsContext())
             {
                  ctx.Departamento.Add(departamento);
                  ctx.SaveChanges();
             }
        }
    }
}

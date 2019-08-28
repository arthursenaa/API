using $safeprojectname$.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace $safeprojectname$.Repositories
{
    public class CargosRepository
    {

        public string StringConexao = "Data Source=localhost;Initial Catalog=T_Ekips;User Id=sa;Pwd=132";


        public List<Cargo> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargo.ToList();
            }
        }

        public Cargo ListarPorId(int Id)
        {

            string Query = "Select * from Cargo where IdCargo = @Id ";

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
                            Cargo Cargo = new Cargo()
                            {
                                IdCargo = Convert.ToInt32(sdr["IdCargo"]),
                                Cargo1 = sdr["Cargo"].ToString()
                            };

                            return Cargo;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(Cargo cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargo.Add(cargos);
                ctx.SaveChanges();
            }
        }
    }
}

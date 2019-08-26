using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repositorio
{
    public class GeneroRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select * FROM Generos";
                con.Open();
            }

        }
    }
}

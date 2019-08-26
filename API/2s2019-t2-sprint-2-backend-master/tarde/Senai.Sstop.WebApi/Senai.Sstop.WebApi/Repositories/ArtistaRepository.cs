using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        //private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_SStop;User Id=sa;Pwd=132;";
        //private string StringConexao = "Data Source=.\\localhost;Initial Catalog=T_SStop;Integrated Security=true;";
        //private string StringConexao = "Data Source=\\DESKTOP-2IB4EPN;Initial Catalog=T_SStop;Integrated Security=true;";
        private string StringConexao = "Data Source=localhost;Initial Catalog=T_SStop;User Id=sa;Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            string Query = "SELECT A.IdArtista, A.Nome, E.IdEstilo, E.Nome AS NomeEstilo FROM Artistas AS A INNER JOIN Estilos AS E ON A.IdEstilo = E.IdEstilo; ";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtista"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                            IdEstilo = Convert.ToInt32(sdr["IdEstilo"]),
                            Nome = sdr["NomeEstilo"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }
                }
            }
            return artistas;
        }
    }
}

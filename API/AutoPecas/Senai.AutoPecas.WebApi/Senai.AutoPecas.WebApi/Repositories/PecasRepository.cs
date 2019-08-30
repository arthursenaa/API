using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository
    {
        private string StringConexao = "Data Source=localhost; initial catalog=T_AutoPecas;User Id=sa;Pwd=132";

        public List<Pecas> Listar()
        {
            using(AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }

        public Pecas ListarId(int Id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == Id);
            }
        }
    }
}

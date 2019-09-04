using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository : IPecasRepository
    {

        AutoPecasContext ctx = new AutoPecasContext();
        private string StringConexao = "Data Source=localhost; initial catalog=T_AutoPecas;User Id=sa;Pwd=132";



        public List<Pecas> Listar()
        {
            return ctx.Pecas.ToList();            
        }


        public Pecas ListarId(int Id)
        {
            return ctx.Pecas.FirstOrDefault(x => x.IdPeca == Id);           
        }


        public void AtualizarPeca(Pecas peca)
        {
            Pecas buscada = ctx.Pecas.FirstOrDefault(x => x.IdPeca == peca.IdPeca);
            ctx.Pecas.Update(buscada);
            ctx.SaveChanges();
        }


        public void CadastrarPeca(Pecas peca)
        {
            ctx.Pecas.Add(peca);
            ctx.SaveChanges();
        }


        public void DeletarPeca(int id)
        {
            Pecas pecas = ctx.Pecas.Find(id);
            ctx.Pecas.Remove(pecas);
            ctx.SaveChanges();
        }
    }
}

using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilos);
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Atualizar(Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilos.IdEstilo);
                EstiloBuscado.Nome = estilos.Nome;
                ctx.Estilos.Update(EstiloBuscado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos Estilos = ctx.Estilos.Find(id);

                ctx.Estilos.Remove(Estilos);

                ctx.SaveChanges();
            }
        }
    }
}

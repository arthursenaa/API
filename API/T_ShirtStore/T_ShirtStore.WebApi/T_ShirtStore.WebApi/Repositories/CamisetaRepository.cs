using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.Interface;

namespace T_ShirtStore.WebApi.Repositories
{
    public class CamisetaRepository : ICamisaRepository
    {

        ShirtStoreContext ctx = new ShirtStoreContext();

        public void Atualizar(Camisa camisa)
        {
            Camisa e = ctx.Camisa.FirstOrDefault(x => x.IdCamisa == camisa.IdCamisa);
            e.Nome = camisa.Nome;
            ctx.Camisa.Update(e);
            ctx.SaveChanges();
        }

        public void Cadastrar(Camisa camisa)
        {
            ctx.Camisa.Add(camisa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Camisa camisa = ctx.Camisa.Find(id);
            ctx.Camisa.Remove(camisa);
            ctx.SaveChanges();
        }

        public List<Camisa> Listar()
        {
            return ctx.Camisa.ToList();
        }
    }
}

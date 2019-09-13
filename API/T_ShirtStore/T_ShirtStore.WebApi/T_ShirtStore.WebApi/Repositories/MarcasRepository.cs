using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.Interface;

namespace T_ShirtStore.WebApi.Repositories
{
    public class MarcasRepository : IMarcasRepository
    {

        ShirtStoreContext ctx = new ShirtStoreContext();

        public void Atualizar(Empresa empresa)
        {
            Empresa e = ctx.Empresa.FirstOrDefault(x => x.IdEmpresa == empresa.IdEmpresa);
            e.Nome = empresa.Nome;
            ctx.Empresa.Update(e);
            ctx.SaveChanges();
        }

        public void Cadastrar(Empresa empresa)
        {
            ctx.Empresa.Add(empresa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresa = ctx.Empresa.Find(id);
            ctx.Empresa.Remove(empresa);
            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresa.Include(x => x.Usuario).ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    //public string StringConexao = "Data Source=localhost;Initial Catalog=T_Gufos;User Id=sa;Pwd=132";

    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }
        // buscar por id
        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }
        //Atualizar
        public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.Nome = categoria.Nome;
                ctx.Categorias.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }


        //Deletar
        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias Categoria = ctx.Categorias.Find(id);

                ctx.Categorias.Remove(Categoria);

                ctx.SaveChanges();
            }
        }

    }
}

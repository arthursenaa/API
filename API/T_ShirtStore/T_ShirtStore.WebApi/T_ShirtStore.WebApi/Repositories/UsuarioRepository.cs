using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.Interface;

namespace T_ShirtStore.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        ShirtStoreContext ctx = new ShirtStoreContext();


        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }

        public void CadastrarUsuario(Usuario user)
        {
            ctx.Usuario.Add(user);
            ctx.SaveChanges();
        }

        public void Atualizar(Usuario user)
        {
            //Usuario UserBuscado = ctx.Usuario.FirstOrDefault(x => x.IdUsuario == user.IdUsuario);
            //UserBuscado.Email = user.Email;
            //UserBuscado.Senha = user.Senha;

            ctx.Usuario.Update(user);
            ctx.SaveChanges();
        }
        
        public void Deletar(int id)
        {
            

            Usuario user = ctx.Usuario.Find(id);
            ctx.Usuario.Remove(user);
            ctx.SaveChanges();
        }

        

    }
}

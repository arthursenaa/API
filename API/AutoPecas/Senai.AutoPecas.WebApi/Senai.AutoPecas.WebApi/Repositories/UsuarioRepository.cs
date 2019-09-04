using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        AutoPecasContext ctx = new AutoPecasContext();


        public Usuario BuscarPorEmailESenha(LoginViewModel login)
        {
                Usuario UsuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
        }

        public void Cadastrar(Usuario usuario)
        {
            ctx.Usuario.Add(usuario);
            ctx.SaveChanges();
        }
    }
}

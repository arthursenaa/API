using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.Interface;
using T_ShirtStore.WebApi.ViewModel;

namespace T_ShirtStore.WebApi.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        ShirtStoreContext ctx = new ShirtStoreContext();


        public Usuario BuscarEmailESenha(LoginViewModel login)
        {
            Usuario UsuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            if (UsuarioBuscado == null)
            {
                return null;
            }
            return UsuarioBuscado;
        }

 
    }
}

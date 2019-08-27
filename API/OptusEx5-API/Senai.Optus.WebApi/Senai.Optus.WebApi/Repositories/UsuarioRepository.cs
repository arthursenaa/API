using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios Login(LoginViewModel login)
        {
            using (OptusContext cx = new OptusContext())
            {
                Usuarios usuarios = cx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarios == null)
                    return null;
                return usuarios; 
            }
        }

    }
}

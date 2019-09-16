using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;

namespace T_ShirtStore.WebApi.Interface
{
    interface IUsuarioRepository
    {

        List<Usuario> Listar();
        void CadastrarUsuario(Usuario user);
        void Atualizar(Usuario user);
        void Deletar(int id);

    }
}

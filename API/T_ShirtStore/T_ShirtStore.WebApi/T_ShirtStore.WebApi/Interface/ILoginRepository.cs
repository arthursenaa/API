using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;
using T_ShirtStore.WebApi.ViewModel;

namespace T_ShirtStore.WebApi.Interface
{
    interface ILoginRepository
    {
        Usuario BuscarEmailESenha(LoginViewModel login);
    }
}

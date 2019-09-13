using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;

namespace T_ShirtStore.WebApi.Interface
{
    interface IMarcasRepository
    {
        List<Empresa> Listar();
        void Cadastrar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Deletar(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_ShirtStore.WebApi.Domains;

namespace T_ShirtStore.WebApi.Interface
{
    interface ICamisaRepository
    {
        List<Camisa> Listar();
        void Cadastrar(Camisa camisa);
        void Atualizar(Camisa camisa);
        void Deletar(int id);
    }
}

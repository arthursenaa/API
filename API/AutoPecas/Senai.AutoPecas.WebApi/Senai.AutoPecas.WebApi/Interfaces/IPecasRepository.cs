using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IPecasRepository
    {

        List<Pecas> Listar();
        void CadastrarPeca(Pecas peca);
        Pecas ListarId(int Id);
        void AtualizarPeca(Pecas peca);
        void DeletarPeca(int id);
    }
}

using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IFornecedorRepository
    {
        void CadastrarFornecedor(Fornecedor fornecedor);
        void AtualizarFornecedor(Fornecedor fornecedor);
        void DeletarFornecedor(int id);
    }
}

using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        AutoPecasContext ctx = new AutoPecasContext();

        public void AtualizarFornecedor(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public void CadastrarFornecedor(Fornecedor fornecedor)
        {
            ctx.Fornecedor.Add(fornecedor);
            ctx.SaveChanges();
        }

        public void DeletarFornecedor(int id)
        {
            throw new NotImplementedException();
        }
    }
}

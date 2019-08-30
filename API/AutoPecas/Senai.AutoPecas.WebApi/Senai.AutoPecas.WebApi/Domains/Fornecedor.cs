using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            Pecas = new HashSet<Pecas>();
        }

        public int IdFornecedor { get; set; }
        public int Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Pecas> Pecas { get; set; }
    }
}

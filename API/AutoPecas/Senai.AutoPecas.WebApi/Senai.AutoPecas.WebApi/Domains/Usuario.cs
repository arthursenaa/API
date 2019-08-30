using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Fornecedor = new HashSet<Fornecedor>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Fornecedor> Fornecedor { get; set; }
    }
}

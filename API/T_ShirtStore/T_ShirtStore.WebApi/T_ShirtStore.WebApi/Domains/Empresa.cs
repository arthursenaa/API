using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            EmpresaEstoque = new HashSet<EmpresaEstoque>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdEmpresa { get; set; }
        public string Nome { get; set; }

        public ICollection<EmpresaEstoque> EmpresaEstoque { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}

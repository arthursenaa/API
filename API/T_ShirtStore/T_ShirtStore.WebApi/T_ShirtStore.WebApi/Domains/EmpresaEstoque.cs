using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class EmpresaEstoque
    {
        public int Id { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdEstoque { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
        public Estoque IdEstoqueNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdEmpresa { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdPermissao { get; set; }

        public Permissao IdPermissaoNavigation { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}

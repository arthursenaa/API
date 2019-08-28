using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domains
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdCargo { get; set; }
        public string Cargo1 { get; set; }
        public int? IdAtivo { get; set; }

        public Ativo IdAtivoNavigation { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}

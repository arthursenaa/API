using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domains
{
    public partial class Ativo
    {
        public Ativo()
        {
            Cargo = new HashSet<Cargo>();
        }

        public int IdAtividade { get; set; }
        public string Ativo1 { get; set; }

        public ICollection<Cargo> Cargo { get; set; }
    }
}

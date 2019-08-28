using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domains
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdDepartamento { get; set; }
        public string Departamento1 { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}

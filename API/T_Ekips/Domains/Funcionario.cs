using System;
using System.Collections.Generic;

namespace $safeprojectname$.Domains
{
    public partial class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Salario { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdCargo { get; set; }
        public int? IdUsuario { get; set; }

        public Cargo IdCargoNavigation { get; set; }
        public Departamento IdDepartamentoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
    }
}

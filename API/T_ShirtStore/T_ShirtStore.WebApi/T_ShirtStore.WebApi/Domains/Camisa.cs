using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class Camisa
    {
        public Camisa()
        {
            Estoque = new HashSet<Estoque>();
        }

        public int IdCamisa { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }

        public ICollection<Estoque> Estoque { get; set; }
    }
}

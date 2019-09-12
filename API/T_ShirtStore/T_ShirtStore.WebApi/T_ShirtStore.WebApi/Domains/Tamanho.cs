using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class Tamanho
    {
        public Tamanho()
        {
            Estoque = new HashSet<Estoque>();
        }

        public int IdTamanho { get; set; }
        public string Tamanho1 { get; set; }

        public ICollection<Estoque> Estoque { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class Estoque
    {
  

        public int IdEstoque { get; set; }
        public int Camisa { get; set; }
        public int Tamanho { get; set; }
        public string Cor { get; set; }

        public Camisa CamisaNavigation { get; set; }
        public Tamanho TamanhoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Senai.Gufos.WebApi.Domains
{
    public partial class Eventos
    {
        public int IdEventos { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEvento { get; set; }
        public bool? Ativo { get; set; }
        public string Localizaçao { get; set; }
        public int? IdCategoria { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Permissao
    {
        public Permissao()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdPermissao { get; set; }
        public string Permissao1 { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}

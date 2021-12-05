using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Status { get; set; }

        public virtual Comprador Comprador { get; set; }
        public virtual Loja Loja { get; set; }
    }
}

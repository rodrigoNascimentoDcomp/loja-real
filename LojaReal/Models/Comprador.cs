using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class Comprador
    {
        public long Cpf { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string UsuarioLogin { get; set; }

        public virtual Usuario UsuarioLoginNavigation { get; set; }
    }
}

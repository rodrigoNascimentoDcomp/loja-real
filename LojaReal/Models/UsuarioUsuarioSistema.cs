using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class UsuarioUsuarioSistema
    {
        public string UsuarioLogin { get; set; }
        public string UsuarioSistemaLogin { get; set; }
        public DateTime Data { get; set; }
        public string Operacao { get; set; }

        public virtual Usuario UsuarioLoginNavigation { get; set; }
        public virtual UsuarioSistema UsuarioSistemaLoginNavigation { get; set; }
    }
}

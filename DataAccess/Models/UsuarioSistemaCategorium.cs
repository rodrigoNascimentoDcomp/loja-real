using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class UsuarioSistemaCategorium
    {
        public string UsuarioSistemaLogin { get; set; }
        public int CategoriaId { get; set; }
        public DateTime Data { get; set; }
        public string Operacao { get; set; }

        public virtual Categorium Categoria { get; set; }
        public virtual UsuarioSistema UsuarioSistemaLoginNavigation { get; set; }
    }
}

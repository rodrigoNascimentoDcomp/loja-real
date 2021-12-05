using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class CategoriaProduto
    {
        public int CategoriaId { get; set; }
        public int ProdutoId { get; set; }

        public virtual Categorium Categoria { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Catalogo
    {
        public long LojaCnpj { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Detalhes { get; set; }

        public virtual Loja LojaCnpjNavigation { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

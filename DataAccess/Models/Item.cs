using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Item
    {
        public int Numero { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int CompraId { get; set; }

        public virtual Compra Compra { get; set; }
    }
}

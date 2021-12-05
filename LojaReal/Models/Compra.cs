using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class Compra
    {
        public Compra()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}

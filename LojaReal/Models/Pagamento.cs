using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class Pagamento
    {
        public int Parcelas { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }
        public int CompraId { get; set; }

        public virtual Compra Compra { get; set; }
    }
}

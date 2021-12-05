using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class CompraStatus
    {
        public int CompraId { get; set; }
        public int StatusId { get; set; }
        public DateTime Data { get; set; }

        public virtual Compra Compra { get; set; }
        public virtual Status Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class OrderItem : Item
    {
        public decimal Discount { get; set; }
        public decimal Total { get => Price - Discount; }
    }
}

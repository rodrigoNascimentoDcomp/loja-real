using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get => Item.Price - Discount; }
        public Order Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal PriceTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal OrderTotal { get => PriceTotal - DiscountTotal; }
        public OrderStatus Status { get; set; }
    }
}

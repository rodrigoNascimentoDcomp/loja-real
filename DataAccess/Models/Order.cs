using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal Total { get => Price - (Price * DiscountPercentage / 100); }
        public OrderStatus Status { get; set; }

        public int ItemId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly StoreContext _context;

        public OrderItemRepository(StoreContext context) : base(context)
        {
            _context = context;
        }

        public decimal GetAverageSellingPrice(int itemId)
        {
            return _context.OrderItems
                .Where(x => x.Item.ItemId == itemId)
                .Average(x => x.TotalPerUnit);
        }
    }
}

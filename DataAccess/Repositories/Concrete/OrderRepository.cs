using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly StoreContext _context;

        public OrderRepository(StoreContext context) : base(context)
        {
            _context = context;
        }
    }
}

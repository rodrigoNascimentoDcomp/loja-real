using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        decimal GetAverageSellingPrice(int itemId);
    }
}

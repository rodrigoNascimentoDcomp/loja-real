using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        int Save();

        void Dispose();
    }
}

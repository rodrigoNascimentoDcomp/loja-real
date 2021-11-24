using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreContext _context;

        private IItemRepository _itemRepository;
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(StoreContext context) => _context = context;

        public IItemRepository ItemRepository =>
            _itemRepository ??= new ItemRepository(_context);
        public IOrderRepository OrderRepository =>
            _orderRepository ??= new OrderRepository(_context);
        public IOrderItemRepository OrderItemRepository =>
            _orderItemRepository ??= new OrderItemRepository(_context);
        public IProductCategoryRepository ProductCategoryRepository =>
            _productCategoryRepository ??= new ProductCategoryRepository(_context);
        public IProductRepository ProductRepository =>
            _productRepository ??= new ProductRepository(_context);

        public int Save() => _context.SaveChanges();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using DataAccess.Models;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<OrderItem> Get(
            Expression<Func<OrderItem, bool>> filter = null,
            Func<IQueryable<OrderItem>, IOrderedQueryable<OrderItem>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.OrderItemRepository.Get(filter, orderBy, includeProperties);

        public OrderItem GetByID(int id) => _unitOfWork.OrderItemRepository.GetByID(id);

        public void Insert(OrderItem entity) => _unitOfWork.OrderItemRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.OrderItemRepository.Delete(id);

        public void Update(OrderItem entityToUpdate) => _unitOfWork.OrderItemRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.OrderItemRepository.Save();
    }
}

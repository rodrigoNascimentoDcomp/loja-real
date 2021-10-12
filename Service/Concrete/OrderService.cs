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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Order> Get(
            Expression<Func<Order, bool>> filter = null,
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.OrderRepository.Get(filter, orderBy, includeProperties);

        public Order GetByID(int id) => _unitOfWork.OrderRepository.GetByID(id);

        public void Insert(Order entity) => _unitOfWork.OrderRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.OrderRepository.Delete(id);

        public void Update(Order entityToUpdate) => _unitOfWork.OrderRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.OrderRepository.Save();
    }
}

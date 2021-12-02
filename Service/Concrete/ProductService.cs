using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Produto> Get(
            Expression<Func<Produto, bool>> filter = null,
            Func<IQueryable<Produto>, IOrderedQueryable<Produto>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.ProductRepository.Get(filter, orderBy, includeProperties);

        public Produto GetByID(int id) => _unitOfWork.ProductRepository.GetByID(id);

        public void Insert(Produto entity) => _unitOfWork.ProductRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.ProductRepository.Delete(id);

        public void Update(Produto entityToUpdate) => _unitOfWork.ProductRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.ProductRepository.Save();
    }
}

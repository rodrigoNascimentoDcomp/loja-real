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

        public IEnumerable<Product> Get(
            Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.ProductRepository.Get(filter, orderBy, includeProperties);

        public Product GetByID(int id) => _unitOfWork.ProductRepository.GetByID(id);

        public void Insert(Product entity) => _unitOfWork.ProductRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.ProductRepository.Delete(id);

        public void Update(Product entityToUpdate) => _unitOfWork.ProductRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.ProductRepository.Save();
    }
}

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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> Get(
            Expression<Func<ProductCategory, bool>> filter = null,
            Func<IQueryable<ProductCategory>, IOrderedQueryable<ProductCategory>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.ProductCategoryRepository.Get(filter, orderBy, includeProperties);

        public ProductCategory GetByID(int id) => _unitOfWork.ProductCategoryRepository.GetByID(id);

        public void Insert(ProductCategory entity) => _unitOfWork.ProductCategoryRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.ProductCategoryRepository.Delete(id);

        public void Update(ProductCategory entityToUpdate) => _unitOfWork.ProductCategoryRepository.Update(entityToUpdate);
    }
}

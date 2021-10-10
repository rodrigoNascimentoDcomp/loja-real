using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ProductSummaryService : IProductSummaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductSummaryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<ProductSummary> Get()
        {
            var summary = from product in _unitOfWork.ProductRepository.Get()
                          join productCategory in _unitOfWork.ProductCategoryRepository.Get()
                          on product.ProductCategoryId equals productCategory.ProductCategoryId
                          select new ProductSummary()
                          {
                              ProductId = product.ProductId,
                              ProductName = product.Name,
                              ProductCategoryId = productCategory.ProductCategoryId,
                              ProductCategoryName = productCategory.Name
                          };

            return summary;
        }
    }
}

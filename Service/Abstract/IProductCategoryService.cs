using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;

namespace Service.Abstract
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> Get(
            Expression<Func<ProductCategory, bool>> filter = null,
            Func<IQueryable<ProductCategory>, IOrderedQueryable<ProductCategory>> orderBy = null,
            string includeProperties = "");

        ProductCategory GetByID(int id);

        void Insert(ProductCategory entity);

        void Delete(int id);

        void Update(ProductCategory entityToUpdate);
    }
}

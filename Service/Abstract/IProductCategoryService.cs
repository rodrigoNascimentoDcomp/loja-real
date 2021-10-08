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
    public interface IProductCategoryService : IGenericService<ProductCategory>
    {
        
    }
}

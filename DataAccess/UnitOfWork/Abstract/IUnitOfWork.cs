using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IProductCategoryRepository ProductCategoryRepository { get; }

        int Save();

        void Dispose();
    }
}

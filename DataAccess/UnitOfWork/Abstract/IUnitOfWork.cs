using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        ICategoriumRepository CategoriumRepository { get; }
        ILojaRepository LojaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        int Save();

        void Dispose();
    }
}

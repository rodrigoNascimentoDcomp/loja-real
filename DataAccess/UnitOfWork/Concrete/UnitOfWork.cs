using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LojaContext _context;

        private ICategoriumRepository _categoriumRepository;
        private IProdutoRepository _produtoRepository;

        public UnitOfWork(LojaContext context) => _context = context;

        public ICategoriumRepository CategoriumRepository =>
            _categoriumRepository ??= new CategoriumRepository(_context);
        
        public IProdutoRepository ProdutoRepository =>
            _produtoRepository ??= new ProdutoRepository(_context);

        public int Save() => _context.SaveChanges();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

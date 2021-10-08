using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class GenericService<T> : IDisposable, IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
        }

        public IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "") =>
            _repository.Get(filter, orderBy, includeProperties);

        public T GetByID(object id) => _repository.GetByID(id);

        public void Insert(T entity) => _repository.Insert(entity);

        public void Delete(object id) => _repository.Delete(id);

        public void Delete(T entityToDelete) => _repository.Delete(entityToDelete);

        public void Update(T entityToUpdate) => _repository.Update(entityToUpdate);

        public void Save()
        {
            _repository.Save();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

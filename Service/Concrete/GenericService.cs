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
    public class GenericService<TEntity> : IDisposable, IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork) =>
            _repository = repository;

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") =>
            _repository.Get(filter, orderBy, includeProperties);

        public TEntity GetByID(object id) => _repository.GetByID(id);

        public void Insert(TEntity entity) => _repository.Insert(entity);

        public void Delete(object id) => _repository.Delete(id);

        public void Delete(TEntity entityToDelete) => _repository.Delete(entityToDelete);

        public void Update(TEntity entityToUpdate) => _repository.Update(entityToUpdate);

        public void Save() => _repository.Save();

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
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

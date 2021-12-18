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
    public class CategoriumService : ICategoriumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriumService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Categorium> Get(
            Expression<Func<Categorium, bool>> filter = null,
            Func<IQueryable<Categorium>, IOrderedQueryable<Categorium>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.CategoriumRepository.Get(filter, orderBy, includeProperties);

        public Categorium GetByID(int id) => _unitOfWork.CategoriumRepository.GetByID(id);

        public void Insert(Categorium entity) => _unitOfWork.CategoriumRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.CategoriumRepository.Delete(id);

        public void Update(Categorium entityToUpdate) => _unitOfWork.CategoriumRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.CategoriumRepository.Save();
    }
}

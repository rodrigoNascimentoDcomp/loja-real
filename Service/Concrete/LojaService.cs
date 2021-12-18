using DataAccess.Models;
using DataAccess.UnitOfWork.Abstract;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class LojaService : ILojaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LojaService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Loja> Get(
            Expression<Func<Loja, bool>> filter = null,
            Func<IQueryable<Loja>, IOrderedQueryable<Loja>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.LojaRepository.Get(filter, orderBy, includeProperties);

        public Loja GetByID(int id) => _unitOfWork.LojaRepository.GetByID(id);

        public void Insert(Loja entity) => _unitOfWork.LojaRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.LojaRepository.Delete(id);

        public void Update(Loja entityToUpdate) => _unitOfWork.LojaRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.LojaRepository.Save();
    }
}

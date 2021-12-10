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
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Produto> Get(
            Expression<Func<Produto, bool>> filter = null,
            Func<IQueryable<Produto>, IOrderedQueryable<Produto>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.ProdutoRepository.Get(filter, orderBy, includeProperties);

        public Produto GetByID(int id) => _unitOfWork.ProdutoRepository.GetByID(id);

        public void Insert(Produto entity) => _unitOfWork.ProdutoRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.ProdutoRepository.Delete(id);

        public void Update(Produto entityToUpdate) => _unitOfWork.ProdutoRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.ProdutoRepository.Save();
    }
}

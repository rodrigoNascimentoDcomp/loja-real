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
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IEnumerable<Item> Get(
            Expression<Func<Item, bool>> filter = null,
            Func<IQueryable<Item>, IOrderedQueryable<Item>> orderBy = null,
            string includeProperties = "") =>
            _unitOfWork.ItemRepository.Get(filter, orderBy, includeProperties);

        public Item GetByID(int id) => _unitOfWork.ItemRepository.GetByID(id);

        public void Insert(Item entity) => _unitOfWork.ItemRepository.Insert(entity);

        public void Delete(int id) => _unitOfWork.ItemRepository.Delete(id);

        public void Update(Item entityToUpdate) => _unitOfWork.ItemRepository.Update(entityToUpdate);

        public void Save() => _unitOfWork.ItemRepository.Save();
    }
}

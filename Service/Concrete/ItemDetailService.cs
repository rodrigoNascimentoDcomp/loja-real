using DataAccess.Models;
using DataAccess.UnitOfWork.Abstract;
using Service.Models;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ItemDetailService : IItemDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ItemDetail> Get()
        {
            return from item in _unitOfWork.ItemRepository.Get()
                   select new ItemDetail()
                   {
                       Item = item,
                       AverageSellingPrice = _unitOfWork.OrderItemRepository.GetAverageSellingPrice(item.ItemId)
                   };
        }
    }
}

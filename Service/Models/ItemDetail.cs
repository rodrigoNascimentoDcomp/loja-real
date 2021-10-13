using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ItemDetail
    {
        public Item Item { get; set; }
        public decimal AverageSellingPrice { get; set; }
    }
}

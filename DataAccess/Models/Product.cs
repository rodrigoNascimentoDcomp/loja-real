using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}

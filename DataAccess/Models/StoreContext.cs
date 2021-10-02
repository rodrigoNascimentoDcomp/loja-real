using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base()
        {

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}

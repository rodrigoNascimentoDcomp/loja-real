using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class CategoriumRepository : GenericRepository<Categorium>, ICategoriumRepository
    {
        public CategoriumRepository(LojaContext context) : base(context)
        {

        }
    }
}

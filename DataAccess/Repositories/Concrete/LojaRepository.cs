using DataAccess.Models;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class LojaRepository : GenericRepository<Loja>, ILojaRepository
    {
        public LojaRepository(LojaContext context) : base(context)
        {

        }
    }
}

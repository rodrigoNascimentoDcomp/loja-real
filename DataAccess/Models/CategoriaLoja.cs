using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class CategoriaLoja
    {
        public long LojaCnpj { get; set; }
        public int CateogriaId { get; set; }

        public virtual Categorium Cateogria { get; set; }
        public virtual Loja LojaCnpjNavigation { get; set; }
    }
}

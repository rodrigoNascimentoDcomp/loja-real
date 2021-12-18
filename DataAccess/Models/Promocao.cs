using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Promocao
    {
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public long LojaCnpj { get; set; }

        public virtual Loja LojaCnpjNavigation { get; set; }
    }
}

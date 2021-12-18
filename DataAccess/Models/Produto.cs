using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especificacao { get; set; }
        public string Status { get; set; }
    }
}

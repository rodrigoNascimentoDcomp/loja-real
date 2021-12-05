using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class CartaoCredito
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Titular { get; set; }
        public long Cpf { get; set; }
        public DateTime Data { get; set; }
    }
}

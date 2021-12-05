using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Rua { get; set; }
        public string Estado { get; set; }
        public string Bairro { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Nome { get; set; }
    }
}

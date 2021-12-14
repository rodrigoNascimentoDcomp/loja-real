using LojaReal.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LojaReal.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [StringLength(45)]
        public string Nome { get; set; }
        [StringLength(45)]
        public string Especificacao { get; set; }
        public ProdutoStatus Status { get; set; }
    }
}

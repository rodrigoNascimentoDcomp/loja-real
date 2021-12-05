using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Loja
    {
        public Loja()
        {
            Promocaos = new HashSet<Promocao>();
        }

        public long Cnpj { get; set; }
        public string Nome { get; set; }
        public int NumeroDeVendas { get; set; }
        public string UsuarioLogin { get; set; }

        public virtual Usuario UsuarioLoginNavigation { get; set; }
        public virtual ICollection<Promocao> Promocaos { get; set; }
    }
}

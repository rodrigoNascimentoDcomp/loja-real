﻿using System;
using System.Collections.Generic;

#nullable disable

namespace LojaReal.Models
{
    public partial class SolicitaCadastro
    {
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public string Observacao { get; set; }
    }
}

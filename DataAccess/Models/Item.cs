﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

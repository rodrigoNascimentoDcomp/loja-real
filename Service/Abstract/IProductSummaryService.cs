﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IProductSummaryService
    {
        public IEnumerable<ProductSummary> Get();
    }
}
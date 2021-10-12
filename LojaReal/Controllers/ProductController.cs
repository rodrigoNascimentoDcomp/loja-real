using DataAccess.Models;
using LojaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LojaReal.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var summary = Seed();

            return View(summary);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IEnumerable<Product> Seed()
        {
            ProductCategory firstCategory = new()
            {
                ProductCategoryId = 1,
                Name = "category 1"
            };
            
            ProductCategory secondCategory = new()
            {
                ProductCategoryId = 2,
                Name = "category 2"
            };

            List<Product> summary = new()
            {
                new Product()
                {
                    ProductId = 1,
                    Name = "product 1",
                    Category = firstCategory
                },
                new Product()
                {
                    ProductId = 2,
                    Name = "product 2",
                    Category = secondCategory
                }
            };

            return summary;
        }
    }
}

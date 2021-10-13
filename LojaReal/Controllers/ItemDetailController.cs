using DataAccess.Models;
using LojaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LojaReal.Controllers
{
    public class ItemDetailController : Controller
    {
        private readonly ILogger<ItemDetailController> _logger;
        private readonly IItemDetailService _itemDetailService;

        public ItemDetailController(ILogger<ItemDetailController> logger, IItemDetailService itemDetailService)
        {
            _logger = logger;
            _itemDetailService = itemDetailService;
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

        private IEnumerable<ItemDetail> Seed()
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

            List<Product> products = new()
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

            List<Item> items = new()
            {
                new Item()
                {
                    ItemId = 1,
                    Stock = 100,
                    Price = 10M,
                    ProductId = 1,
                    Product = products[0]
                },
                new Item()
                {
                    ItemId = 2,
                    Stock = 50,
                    Price = 50M,
                    ProductId = 2,
                    Product = products[1]
                }
            };

            List<ItemDetail> itemDetails = new()
            {
                new ItemDetail()
                {
                    Item = items[0],
                    AverageSellingPrice = 9.50M
                },
                new ItemDetail()
                {
                    Item = items[1],
                    AverageSellingPrice = 48.99M
                }
            };

            return itemDetails;
        }
    }
}

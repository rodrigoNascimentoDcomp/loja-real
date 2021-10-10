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
    public class ProductSummaryController : Controller
    {
        private readonly ILogger<ProductSummaryController> _logger;
        private readonly IProductSummaryService _productSummaryService;

        public ProductSummaryController(ILogger<ProductSummaryController> logger, IProductSummaryService productSummaryService)
        {
            _logger = logger;
            _productSummaryService = productSummaryService;
        }

        public IActionResult Index()
        {
            var summary = _productSummaryService.Get();

            return View(summary);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

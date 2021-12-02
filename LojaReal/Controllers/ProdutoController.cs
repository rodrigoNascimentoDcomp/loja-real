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
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var summary = _produtoService.Get();

            return View(summary);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using LojaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using System.Diagnostics;
using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LojaReal.Controllers
{
    public class CategoriumController : Controller
    {
        private readonly ILogger<CategoriumController> _logger;
        private readonly ICategoriumService _categoriumService;

        public CategoriumController(ILogger<CategoriumController> logger, ICategoriumService categoriumService)
        {
            _logger = logger;
            _categoriumService = categoriumService;
        }

        public IActionResult Index()
        {
            var categorium = _categoriumService.Get();
            return View(categorium);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View("Cadastro");
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorium categoria)
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException();

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            _categoriumService.Insert(categoria);
            _categoriumService.Save();

            return RedirectToAction("Index", "Categorium");
        }

        public IActionResult Alteracao(int id)
        {
            var categoria = _categoriumService.GetByID(id);

            if (categoria == null)
                throw new InvalidOperationException();

            return View("Alteracao", categoria);
        }

        [HttpPost]
        public IActionResult Alterar(Categorium categoria)
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException();

            if (categoria == null)
                throw new ArgumentNullException(nameof(categoria));

            _categoriumService.Update(categoria);
            _categoriumService.Save();

            return RedirectToAction("Index", "Categorium");
        }

        [HttpPost]
        public IActionResult Remover(int id)
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException();

            var produto = _categoriumService.GetByID(id);

            if (produto == null)
                throw new InvalidOperationException();

            _categoriumService.Delete(produto.Id);
            _categoriumService.Save();

            return RedirectToAction("Index", "Categorium");
        }
    }
}

﻿using AutoMapper;
using DataAccess.Models;
using LojaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LojaReal.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IMapper mapper, IProdutoService produtoService)
        {
            _logger = logger;
            _mapper = mapper;
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var produtos = _produtoService.Get();
            var produtoModels = _mapper.Map<IEnumerable<Produto>, List<ProdutoModel>>(produtos);
            return View(produtoModels);
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
        public IActionResult Cadastrar(Produto produto)
        {
            if (!ModelState.IsValid)
                throw new InvalidOperationException();

            if (produto == null)
                throw new ArgumentNullException(nameof(produto));

            _produtoService.Insert(produto);

            return View("Index");
        }
    }
}

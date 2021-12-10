using LojaReal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Abstract;
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
    }
}

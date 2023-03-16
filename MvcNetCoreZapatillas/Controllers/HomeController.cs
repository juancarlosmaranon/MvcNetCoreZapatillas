using Microsoft.AspNetCore.Mvc;
using MvcNetCoreZapatillas.Models;
using MvcNetCoreZapatillas.Repositories;
using System.Diagnostics;

namespace MvcNetCoreZapatillas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryZapatillas repo;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
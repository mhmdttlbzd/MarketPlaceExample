using MarketPlace.Domain.Core.Application.Contract.Repositories._Admin;
using MarketPlace.Endpoint.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.Endpoint.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IAdminRepo adminRepo)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int errorCode)
        {
            return View(errorCode);
        }
    }
}
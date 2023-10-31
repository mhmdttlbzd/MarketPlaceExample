using MarketPlace.Domain.Core.Application.Contract.Repositories._Admin;
using MarketPlace.Endpoint.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.Endpoint.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminRepo _adminRepo;

        public HomeController(ILogger<HomeController> logger, IAdminRepo adminRepo)
        {
            _logger = logger;
            _adminRepo = adminRepo;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var res = await _adminRepo.GetByIdAsync(1, cancellationToken);
            return View(res);
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
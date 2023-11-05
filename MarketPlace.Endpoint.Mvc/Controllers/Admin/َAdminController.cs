using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MarketPlace.Endpoint.Mvc.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminPanelAppService _adminPanelAppService;

        public AdminController(IAdminPanelAppService adminPanelAppService)
        {
            _adminPanelAppService = adminPanelAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _adminPanelAppService.GetInformation(cancellationToken));

        }
    }
}

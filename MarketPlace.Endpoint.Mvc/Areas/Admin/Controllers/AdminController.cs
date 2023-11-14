﻿using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
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

        public async Task<IActionResult> SaledProducts(CancellationToken cancellationToken)
        {
            return View(await _adminPanelAppService.GetSaledProducts(cancellationToken));
        }

        public async Task<IActionResult> WalletTransactions(CancellationToken cancellationToken)
        {
            return View(await _adminPanelAppService.GetAllWalletTransactions(cancellationToken));
        }

        public async Task<IActionResult> AllCustomers(CancellationToken cancellationToken)
        {
            return View(await _adminPanelAppService.GetAllCustomers(cancellationToken));
        }
        public async Task<IActionResult> AllSalers(CancellationToken cancellationToken)
        {
            return View(await _adminPanelAppService.GetAllSalers(cancellationToken));
        }

        public async Task<IActionResult> DeActiveUser(int id, CancellationToken cancellationToken)
        {
            await _adminPanelAppService.DeActiveUser(id, cancellationToken);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ActiveUser(int id, CancellationToken cancellationToken)
        {
            await _adminPanelAppService.ActiveUser(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
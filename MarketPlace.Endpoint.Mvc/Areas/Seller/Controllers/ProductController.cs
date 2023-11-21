﻿using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Endpoint.Mvc.Areas.Seller.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace MarketPlace.Endpoint.Mvc.Areas.Seller.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IWebHostEnvironment _environment;
        private readonly IBoothProductAppService _boothProductAppService;
        private readonly IAuctionAppService _auctionAppService;
        public ProductController(IProductAppService productAppService, IWebHostEnvironment environment, IBoothProductAppService boothProductAppService, IAuctionAppService auctionAppService)
        {
            _productAppService = productAppService;
            _environment = environment;
            _boothProductAppService = boothProductAppService;
            _auctionAppService = auctionAppService;
        }

        [ActionName("AllProducts")]
        public async Task<IActionResult> AllProducts(CancellationToken cancellationToken)
        {
            return View(await _productAppService.GetAllProducts(cancellationToken));
        }

        public IActionResult CreateBoothProduct(ProductModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoothProduct(ICollection<IFormFile> images,AuctionModel model,CancellationToken cancellationToken)
        {
            var folder = Path.Combine(_environment.WebRootPath, "images/product");
            List<string> paths = new List<string>();
            foreach (var image in images)
            {
                string fileName = new Guid() + image.FileName;
                if (image.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }
                paths.Add("product/"+ fileName);
            }
            await _auctionAppService.Create(paths, model, cancellationToken, User.Identity.Name);
            return RedirectToAction("AllProducts");
        }

        public IActionResult CreateAuction(ProductModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuction(ICollection<IFormFile> images, BoothProductModel model, CancellationToken cancellationToken)
        {
            var folder = Path.Combine(_environment.WebRootPath, "images/product");
            List<string> paths = new List<string>();
            foreach (var image in images)
            {
                string fileName = new Guid() + image.FileName;
                if (image.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }
                paths.Add("product/" + fileName);
            }
            await _boothProductAppService.Create(paths, model, cancellationToken, User.Identity.Name);
            return RedirectToAction("AllProducts");
        }
    }
}

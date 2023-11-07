using MarketPlace.Domain.AppServices.AppLication._Product;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task<IActionResult> AllProducts(CancellationToken cancellationToken)
        {
            return View(await _productAppService.GetAllProducts(cancellationToken));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var comment = await _productAppService.GetByIdAsync( id, cancellationToken);
            return View("EditProducts", comment);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditPost(int id, string name, int categoryId, CancellationToken cancellationToken)
        {
            await _productAppService.UpdateProduct(id,name,categoryId,cancellationToken);
            return LocalRedirect("~/Product/Edit/" + id);
        }



        public IActionResult Create()
        {
            return View("CreateProduct");
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost( string name, int categoryId, CancellationToken cancellationToken)
        {
            await _productAppService.CreateProduct(User.Identity.Name, name, categoryId, cancellationToken);
            return LocalRedirect("~/Product/Create/");
        }
    }
}

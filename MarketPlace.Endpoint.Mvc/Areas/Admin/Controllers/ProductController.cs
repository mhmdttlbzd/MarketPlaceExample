using MarketPlace.Domain.AppServices.AppLication._Product;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IRequestsAppService _requestsAppService;

        public ProductController(IProductAppService productAppService, IRequestsAppService requestsAppService)
        {
            _productAppService = productAppService;
            _requestsAppService = requestsAppService;
        }
        [ActionName("AllProducts")]
        public async Task<IActionResult> AllProducts(CancellationToken cancellationToken)
        {
            return View(await _productAppService.GetAllProducts(cancellationToken));
        }
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var comment = await _productAppService.GetByIdAsync(id, cancellationToken);
            return View("EditProducts", comment);
        }


        [HttpPost]
        public async Task<IActionResult> EditPost(int id, string name, int categoryId, List<ProductAttrModel> attributes, CancellationToken cancellationToken)
        {
            await _productAppService.UpdateProduct(id, name, attributes, categoryId, cancellationToken);
            return RedirectToAction("AllProducts"); 
        }


        [ActionName("Create")]

        public IActionResult Create()
        {
            return View("CreateProduct");
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(string name, int categoryId,List<ProductAttrModel> attributes, CancellationToken cancellationToken)
        {
            await _productAppService.CreateProduct(User.Identity.Name, name,attributes, categoryId, cancellationToken);
            return RedirectToAction("AllProducts");
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmProduct(int id, CancellationToken cancellationToken)
        {
            await _requestsAppService.ConfirmProduct(id, cancellationToken);
            return RedirectToAction("AllProducts");
        }
        [HttpGet]
        public async Task<IActionResult> FaleProduct(int id, CancellationToken cancellationToken)
        {
            await _requestsAppService.FaleProduct(id, cancellationToken);
            return RedirectToAction("AllProducts");
        }


    }
}

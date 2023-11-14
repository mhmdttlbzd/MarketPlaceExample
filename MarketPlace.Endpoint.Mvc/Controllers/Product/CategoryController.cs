using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetByParentId(int id,CancellationToken cancellationToken)
        {
            var res = await _categoryAppService.GetByParentId(id, cancellationToken);
            var t = Json(res);
            return t;
        }
    }
}

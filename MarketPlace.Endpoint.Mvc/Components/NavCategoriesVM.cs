using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "NavCategoriesVM")]
    public class NavCategoriesVM : ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;

        public NavCategoriesVM(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IViewComponentResult Invoke()
        {
            var res = _categoryAppService.GetAll();
            return View(res);
        }
    }
}

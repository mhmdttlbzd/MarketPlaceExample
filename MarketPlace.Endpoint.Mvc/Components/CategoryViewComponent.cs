using MarketPlace.Domain.AppServices.AppLication._Product;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "CategoryVM")]
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryViewComponent(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

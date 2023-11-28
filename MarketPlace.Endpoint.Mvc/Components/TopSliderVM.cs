using MarketPlace.Domain.Core.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "TopSliderVM")]
    public class TopSliderVM : ViewComponent
    {
        public IViewComponentResult Invoke(List<PictureDto> pictures)
        {  
            return View(pictures);
        }
    }
}

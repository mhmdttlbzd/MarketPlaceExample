using ApplicationFrameWorke;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Endpoint.Mvc.Models.Price;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "PriceHistory")]
    public class PriceHistory : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public PriceHistory(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var prises = _boothProductAppService.GetPricesByProductId(productId);
            var res = new ProductPriceDto[prises.Count()];
            var i = 0;
            foreach (var p in prises)
            {
                res[i] = p; i++;
            }
            return View(res);
        }
    } 
}

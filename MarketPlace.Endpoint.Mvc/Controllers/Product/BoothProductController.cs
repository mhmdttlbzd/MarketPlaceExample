using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class BoothProductController : Controller
    {
        private readonly IBoothProductAppService _boothProductAppService;
        private readonly ICommentAppService _commentAppService;

        public BoothProductController(IBoothProductAppService boothProductAppService, ICommentAppService commentAppService)
        {
            _boothProductAppService = boothProductAppService;
            _commentAppService = commentAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var res = await _boothProductAppService.GetById(id, cancellationToken);
            return View(res);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int boothProductId,CancellationToken cancellationToken)
        {
            await _boothProductAppService.AddToCart(User.Identity.Name, boothProductId, cancellationToken);
            return LocalRedirect("~/Home");
        }

        public async Task<IActionResult> AddComment(byte satisfaction,int boothProductId,string description,CancellationToken cancellationToken)
        {
            await _commentAppService.Create(User.Identity.Name,satisfaction,boothProductId,description,cancellationToken);
            return LocalRedirect("~/Home");
        }
    }
}

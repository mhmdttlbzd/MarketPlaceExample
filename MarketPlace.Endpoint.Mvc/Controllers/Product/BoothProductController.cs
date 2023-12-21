using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class BoothProductController : Controller
    {
        private readonly IBoothProductAppService _boothProductAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IWebHostEnvironment _environment;

        public BoothProductController(IBoothProductAppService boothProductAppService, ICommentAppService commentAppService, IWebHostEnvironment environment)
        {
            _boothProductAppService = boothProductAppService;
            _commentAppService = commentAppService;
            _environment = environment;
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

        [Authorize]
        public async Task<IActionResult> AddComment(byte satisfaction,int boothProductId,string description,CancellationToken cancellationToken)
        {
            if (User.Identity != null && User.Identity.Name != null)
            {
                await _commentAppService.Create(User.Identity.Name,satisfaction,boothProductId,description,cancellationToken);
            }
            return LocalRedirect("~/Home");
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomerPictures(ICollection<IFormFile> images,int productId,CancellationToken cancellationToken)
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
            if (User.Identity != null && User.Identity.Name != null)
            {
                await _boothProductAppService.AddCustomerPictures(paths, productId, User.Identity.Name, cancellationToken);
            }
            return LocalRedirect($"~/BoothProduct/Details/{productId}");
        }
    }
}

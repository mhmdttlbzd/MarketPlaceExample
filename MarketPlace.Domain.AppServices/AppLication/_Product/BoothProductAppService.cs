using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;


namespace MarketPlace.Domain.AppServices.AppLication._Product
{
    public class BoothProductAppService : IBoothProductAppService
    {
        private readonly IBoothProductService _boothProductService;
        private readonly IBoothProductsPriceService _boothProductsPriceService;
        private readonly IProductSalerPicService _productSalerPicService;
        private readonly IPictureService _pictureService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly UserManager<ApplicationUser> _sellerManager;

        public BoothProductAppService(IBoothProductService boothProductService, IBoothProductsPriceService boothProductsPriceService, IProductSalerPicService productSalerPicService, IPictureService pictureService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> sellerManager)
        {
            _boothProductService = boothProductService;
            _boothProductsPriceService = boothProductsPriceService;
            _productSalerPicService = productSalerPicService;
            _pictureService = pictureService;
            _unitOfWorks = unitOfWorks;
            _sellerManager = sellerManager;
        }

        public async Task Create(List<string> paths,BoothProductModel model,CancellationToken cancellationToken,string username)
        {
            List<int> picsId = new List<int>();
            foreach (string path in paths)
            {
                int id = await _pictureService.CreateAsync(path, cancellationToken, "کالای قیمت مقطوع");
                picsId.Add(id);
            }
            var user = _sellerManager.FindByNameAsync(username).Result;
            var boothProductId = await _boothProductService.CreateAsync(new (model.Quantity, user.Id, model.ProductId), cancellationToken);
            
            
            await _boothProductsPriceService.CreateAsync(new (boothProductId, DateTime.Now, null, model.Price), cancellationToken);
            foreach (int picId in picsId)
            {
                await _productSalerPicService.CreateAsync(new (picId, boothProductId), cancellationToken);
            }
        }
    }
}

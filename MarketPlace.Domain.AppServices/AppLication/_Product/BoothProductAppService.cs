using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderLineService _orderLineService;

        public BoothProductAppService(IBoothProductService boothProductService, IBoothProductsPriceService boothProductsPriceService, IProductSalerPicService productSalerPicService, IPictureService pictureService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> sellerManager, IOrderService orderService, IOrderLineService orderLineService)
        {
            _boothProductService = boothProductService;
            _boothProductsPriceService = boothProductsPriceService;
            _productSalerPicService = productSalerPicService;
            _pictureService = pictureService;
            _unitOfWorks = unitOfWorks;
            _userManager = sellerManager;
            _orderService = orderService;
            _orderLineService = orderLineService;
        }

        public async Task Create(List<string> paths,BoothProductModel model,CancellationToken cancellationToken,string username)
        {
            List<int> picsId = new List<int>();
            foreach (string path in paths)
            {
                int id = await _pictureService.CreateAsync(path, cancellationToken, "کالای قیمت مقطوع");
                picsId.Add(id);
            }
            var user = _userManager.FindByNameAsync(username).Result;
            var boothProductId = await _boothProductService.CreateAsync(new (model.Quantity, user.Id, model.ProductId), cancellationToken);
            
            
            await _boothProductsPriceService.CreateAsync(new (boothProductId, DateTime.Now, null, model.Price), cancellationToken);
            foreach (int picId in picsId)
            {
                await _productSalerPicService.CreateAsync(new (picId, boothProductId), cancellationToken);
            }
        }

        public List<GeneralBoothProductDto> GetBestProducts(int Count) => _boothProductService.GetBestProducts(Count);

        public async Task<BoothProductOutputDto> GetById(int id, CancellationToken cancellationToken)
            => await _boothProductService.GetByIdAsync(id, cancellationToken);


        public async Task AddToCart(string userName,int boothProductId, CancellationToken cancellationToken)
        {
            var user =await _userManager.FindByNameAsync(userName);
            int orderId = await _orderService.GetActiveOrderId(user.Id, cancellationToken);
            await _orderLineService.CreateAsync(new OrderLineInputDto(orderId, boothProductId, 1), cancellationToken);
        }

        public List<GeneralBoothProductDto> GetByCategoryId(int id) => _boothProductService.GetByCategoryId(id);

        public List<GeneralBoothProductDto> GetSellerProducts(int sellerId) => _boothProductService.GetSellerProducts(sellerId);
    }
}


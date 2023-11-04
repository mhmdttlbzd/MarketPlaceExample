using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Services.Application._Picture;

namespace MarketPlace.Domain.AppServices.AppLication._Admin
{
	public class AdminPanelAppService : IAdminPanelAppService
	{
		private readonly IWalletService _walletService;
		private readonly ICommentService _commentService;
		private readonly IOrderService _orderService;
		private readonly ICustomerService _customerService;
		private readonly ISalerService _salerService;
		private readonly IProductService _poductService;
		private readonly IProductSalerPicService _productSalerPicService;
		private readonly IProductCustomerPicService _productCustomerPicService;
		private readonly IAuctionPictureService _auctionPictureService;

		public AdminPanelAppService(IWalletService walletService, ICommentService commentService, IOrderService orderService, ICustomerService customerService, ISalerService salerService, IProductService poductService, IProductSalerPicService productSalerPicService, IProductCustomerPicService productCustomerPicService, IAuctionPictureService auctionPictureService)
		{
			_walletService = walletService;
			_commentService = commentService;
			_orderService = orderService;
			_customerService = customerService;
			_salerService = salerService;
			_poductService = poductService;
			_productSalerPicService = productSalerPicService;
			_productCustomerPicService = productCustomerPicService;
			_auctionPictureService = auctionPictureService;
		}

		public async Task<AdminPanelInformationDto> GetInformation(CancellationToken cancellationToken)
		{
			int saledProductCount =await _orderService.GetSaledProductCount(cancellationToken);
			long sumWages =await _walletService.GetAllWage(cancellationToken);
            int productRequests = _auctionPictureService.GetRequestsCount() + _productSalerPicService.GetRequestsCount();
            var saledProductPesent = (saledProductCount *100) / 1000;
            var sumWagesPersent = (int)((sumWages *100) / 10000000);
            var res = new AdminPanelInformationDto
				(
				_commentService.GetRequestsCount(),productRequests,
				_productCustomerPicService.GetRequestsCount(), _poductService.AllRequestsCount(),saledProductCount,
				sumWages, _poductService.GetCount(), _salerService.AllSalersCount(),_customerService.AllCustomersCount(),
				saledProductPesent,sumWagesPersent
				);
			return res;
		}
	}
}

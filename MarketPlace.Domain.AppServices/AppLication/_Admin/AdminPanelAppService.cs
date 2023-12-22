using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services.Log;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._log;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Domain.Core.Identity.Entities;
using MarketPlace.Domain.Services.Application._Picture;
using Microsoft.AspNetCore.Identity;
using System.Threading;

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
        private readonly IOrderLineService _orderLineService;
        private readonly UserManager<Customer> _customerManager;
        private readonly UserManager<Seller> _sellerManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMainAddressService _mainAddressService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IBoothService _boothService;
        private readonly IViewLogService _viewLogService;
        private readonly IErrorLogService _errorLogService;
        private readonly IAuctionService _auctionService;
        private readonly IBoothProductService _boothProductService;
        private readonly ISalerTypeService _salerTypeService;

        public AdminPanelAppService(IWalletService walletService, ICommentService commentService, IOrderService orderService, ICustomerService customerService, ISalerService salerService, IProductService poductService, IProductSalerPicService productSalerPicService, IProductCustomerPicService productCustomerPicService, IAuctionPictureService auctionPictureService, IOrderLineService orderLineService, UserManager<ApplicationUser> userManager, IMainAddressService mainAddressService, IUnitOfWorks unitOfWorks, IBoothService boothService, UserManager<Customer> customerManager, UserManager<Seller> salerManager, IViewLogService viewLogService, IErrorLogService errorLogService, IAuctionService auctionService, IBoothProductService boothProductService, ISalerTypeService salerTypeService)
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
            _orderLineService = orderLineService;
            _userManager = userManager;
            _mainAddressService = mainAddressService;
            _unitOfWorks = unitOfWorks;
            _boothService = boothService;
            _customerManager = customerManager;
            _sellerManager = salerManager;
            _viewLogService = viewLogService;
            _errorLogService = errorLogService;
            _auctionService = auctionService;
            _boothProductService = boothProductService;
            _salerTypeService = salerTypeService;
        }

        public async Task<AdminPanelInformationDto> GetInformation(CancellationToken cancellationToken)
        {
            int saledProductCount = await _orderService.GetSaledProductCount(cancellationToken);
            long sumWages = await _walletService.GetAllWage(cancellationToken);
            int productRequests = _auctionPictureService.GetRequestsCount() + _productSalerPicService.GetRequestsCount();
            var saledProductPesent = (saledProductCount * 100) / 1000;
            var sumWagesPersent = (int)((sumWages * 100) / 10000000);
            var res = new AdminPanelInformationDto
                (
                _commentService.GetRequestsCount(), productRequests,
                _productCustomerPicService.GetRequestsCount(), _poductService.AllRequestsCount(), saledProductCount,
                sumWages, _poductService.GetCount(), _salerService.AllSalersCount(), _customerService.AllCustomersCount(),
                saledProductPesent, sumWagesPersent,
                await _viewLogService.GetViewsCountInThisWeek(),
                await _errorLogService.GetErrorsCountInThisWeek(),
                _commentService.GetCount(),
                _productSalerPicService.GetCount() + _auctionPictureService.GetCount(),
                _productCustomerPicService.GetCount(),
                _auctionService.GetCount(),
                _boothProductService.GetCount(),
                _salerTypeService.GetCount()
                );
            return res;
        }

        public async Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken)
            => await _orderLineService.GetSaledProducts(cancellationToken);
        public async Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken)
            => await _walletService.GetAllWalletTransactions(cancellationToken);


        public async Task<List<GeneralCustomerDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            var customers = await _customerService.GetGeneralCustomers(cancellationToken);
            foreach (var customer in customers)
            {
                var user = await _userManager.FindByIdAsync(customer.Id.ToString());
                customer.Name = user.Name;
                customer.Family = user.Family;
                customer.Email = user.Email;
                customer.Status = user.Status;
            }
            return customers;
        }
        public async Task<List<GeneralSellerDto>> GetAllSalers(CancellationToken cancellationToken)
        {
            var salers = await _salerService.GetGeneralSellers(cancellationToken);
            foreach (var saler in salers)
            {
                var user = await _userManager.FindByIdAsync(saler.Id.ToString());
                saler.Name = user.Name;
                saler.Family = user.Family;
                saler.Email = user.Email;
                saler.Status = user.Status;
            }
            return salers;
        }
        public async Task DeActiveUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Status = UserStatus.DeActive;
            await _userManager.UpdateAsync(user);
        }
        public async Task ActiveUser(int id, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Status = UserStatus.Active;
            await _userManager.UpdateAsync(user);
        }

        public async Task<IEnumerable<ErrorLog>> GetAllErrors() => await _errorLogService.GetAll();
        public async Task<IEnumerable<ErrorLog>> GetErrorsByCode(int code) => await _errorLogService.GetByErrorCode(code);
       
    }
}

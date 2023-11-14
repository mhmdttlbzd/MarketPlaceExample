using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
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
		private readonly UserManager<Saler> _salerManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMainAddressService _mainAddressService;
		private readonly IUnitOfWorks _unitOfWorks;
        private readonly IBoothService _boothService;

        public AdminPanelAppService(IWalletService walletService, ICommentService commentService, IOrderService orderService, ICustomerService customerService, ISalerService salerService, IProductService poductService, IProductSalerPicService productSalerPicService, IProductCustomerPicService productCustomerPicService, IAuctionPictureService auctionPictureService, IOrderLineService orderLineService, UserManager<ApplicationUser> userManager, IMainAddressService mainAddressService, IUnitOfWorks unitOfWorks, IBoothService boothService, UserManager<Customer> customerManager, UserManager<Saler> salerManager)
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
            _salerManager = salerManager;
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

		public async Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken)
			=> await _orderLineService.GetSaledProducts(cancellationToken);
		public async Task<List<WalletTransactionOutputDto>> GetAllWalletTransactions(CancellationToken cancellationToken)
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
        public async Task<List<GeneralSalerDto>> GetAllSalers(CancellationToken cancellationToken)
        {
            var salers = await _salerService.GetGeneralSalers(cancellationToken);
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
        public async Task DeActiveUser(int id , CancellationToken cancellationToken)
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

        public async Task CreateCustomer(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken)
        {
            int addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);
            var customer = new Customer
            {
                Name = inputDto.Name,
                Family = inputDto.Family,
                Email = inputDto.Email,
                UserName = inputDto.Email,
                AddressId = addressId
            };
            await _customerManager.CreateAsync(customer);
            await _customerManager.AddPasswordAsync(customer, inputDto.Password);
            await _customerManager.AddToRoleAsync(customer, "Customer");
        }

        public async Task CreateSaler(GeneralSalerInputDto inputDto, CancellationToken cancellationToken)
        {
            int addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);

            var saler = new Saler
            {
                Name = inputDto.Name,
                Family = inputDto.Family,
                Email = inputDto.Email,
                UserName = inputDto.Email,
                SalerTypeId = inputDto.SalerTypeId
            };
            await _salerManager.CreateAsync(saler);
            await _salerManager.AddPasswordAsync(saler, inputDto.Password);
            await _salerManager.AddToRoleAsync(saler, "Saler");

			await _boothService.CreateAsync(new BoothInputDto(saler.Id, inputDto.BoothName, addressId), cancellationToken);
			await _unitOfWorks.SaveChangesAsync(cancellationToken);
		}
    }
}

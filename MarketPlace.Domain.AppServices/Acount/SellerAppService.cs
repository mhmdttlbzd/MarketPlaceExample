using Hangfire.Storage.Monitoring;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Identity.Contract;
using MarketPlace.Domain.Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.Acount
{
    public class SellerAppService : ISellerAppService
    {
		private readonly IMainAddressService _mainAddressService;
		private readonly ISalerService _salerService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly UserManager<Seller> _sellerManager;
        private readonly IUnitOfWorks _unitOfWorks;
		private readonly IBoothService _boothService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWalletService _walletService;

        public SellerAppService(IMainAddressService mainAddressService, ISalerService salerService, UserManager<ApplicationUser> userManager, IUnitOfWorks unitOfWorks, IBoothService boothService, UserManager<Seller> salerManager, SignInManager<ApplicationUser> signInManager, IWalletService walletService)
        {
            _mainAddressService = mainAddressService;
            _salerService = salerService;
            _userManager = userManager;
            _unitOfWorks = unitOfWorks;
            _boothService = boothService;
            _sellerManager = salerManager;
            _signInManager = signInManager;
            _walletService = walletService;
        }

        public async Task UpdateSeller(GeneralSellerInputDto inputDto, CancellationToken cancellationToken)
		{
			var booth = await _boothService.GetByIdAsync(inputDto.Id, cancellationToken);
            var address = await _mainAddressService.GetByIdAsync(booth.ShopAddressId, cancellationToken);
            int? addressId = booth.ShopAddressId;
			if (inputDto.CityId != -1 || inputDto.CityId != address.CityId || inputDto.AddressDescription != address.Description)
			{
				addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);
			}
			await _boothService.UpdateAsync(new BoothInputDto(inputDto.Id, inputDto.BoothName, addressId),inputDto.Id,cancellationToken);
            await _unitOfWorks.SaveChangesAsync(cancellationToken);

			var saler = await _sellerManager.FindByIdAsync(inputDto.Id.ToString());
            saler.Name = inputDto.Name;
            saler.Family = inputDto.Family;
			saler.Email = inputDto.Email;
			saler.UserName = inputDto.Email;
			await _sellerManager.UpdateAsync(saler);
		}
        public async Task UpdateSeller(GeneralSellerInputDto inputDto, CancellationToken cancellationToken,string userName)
		{
			var user =await _sellerManager.FindByNameAsync(userName);
			inputDto.Id = user.Id;
			await UpdateSeller(inputDto, cancellationToken);

        }

		public async Task<GeneralSellerEditDto> GetByName(string userName,CancellationToken cancellationToken)
		{
            var user = await _sellerManager.FindByNameAsync(userName);
			return await GetById(user.Id, cancellationToken);
        }


        public async Task<GeneralSellerEditDto> GetById(int id,CancellationToken cancellationToken)
		{
			var booth = await _boothService.GetByIdAsync(id, cancellationToken);
			var user = await _userManager.FindByIdAsync(id.ToString());
            var address = await _mainAddressService.GetByIdAsync(booth.ShopAddressId, cancellationToken);
			var saler = new GeneralSellerEditDto
			{
				Id = user.Id,
				Name = user.Name,
				Family = user.Family,
				Email = user.Email,
				BoothName = booth.Name,
				Address = address
			};

			return saler;
		}

		public async Task<GeneralSellerDto> GetGeneral(int id)
		{
			return await _salerService.GetGeneralSeller(id);
		}

        public async Task<Seller> Create(GeneralSellerInputDto inputDto, CancellationToken cancellationToken)
        {
            int addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);

            var seller = new Seller
            {
                Name = inputDto.Name,
                Family = inputDto.Family,
                Email = inputDto.Email,
                UserName = inputDto.Email,
                SellerTypeId = inputDto.SellerTypeId
            };
            await _sellerManager.CreateAsync(seller);
            await _sellerManager.AddPasswordAsync(seller, inputDto.Password);
            await _userManager.AddToRoleAsync(seller, "Seller");

            await _boothService.CreateAsync(new BoothInputDto(seller.Id, inputDto.BoothName, addressId), cancellationToken);
            await _unitOfWorks.SaveChangesAsync(cancellationToken);
            await _walletService.CreateAsync(seller.Id);
            return seller;
        }

        public async Task Register(GeneralSellerInputDto inputDto, CancellationToken cancellationToken)
        {
            inputDto.SellerTypeId = 1;
            var seller = await Create(inputDto, cancellationToken);
            var claim = new Claim(ClaimTypes.Name, seller.UserName);
            await _userManager.AddClaimAsync(seller, claim);
            await _signInManager.PasswordSignInAsync(seller.UserName, inputDto.Password, true, true);
        }
    }
}

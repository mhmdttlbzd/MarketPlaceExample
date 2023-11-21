using Hangfire.Storage.Monitoring;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
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
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.Acount
{
    public class SellerAppService : ISellerAppService
    {
		private readonly IMainAddressService _mainAddressService;
		private readonly ISalerService _salerService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly UserManager<Seller> _salerManager;
        private readonly IUnitOfWorks _unitOfWorks;
		private readonly IBoothService _boothService;

        public SellerAppService(IMainAddressService mainAddressService, ISalerService salerService, UserManager<ApplicationUser> userManager, IUnitOfWorks unitOfWorks, IBoothService boothService, UserManager<Seller> salerManager)
        {
            _mainAddressService = mainAddressService;
            _salerService = salerService;
            _userManager = userManager;
            _unitOfWorks = unitOfWorks;
            _boothService = boothService;
            _salerManager = salerManager;
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

			var saler = await _salerManager.FindByIdAsync(inputDto.Id.ToString());
            saler.Name = inputDto.Name;
            saler.Family = inputDto.Family;
			saler.Email = inputDto.Email;
			saler.UserName = inputDto.Email;
			await _salerManager.UpdateAsync(saler);
		}
        public async Task UpdateSeller(GeneralSellerInputDto inputDto, CancellationToken cancellationToken,string userName)
		{
			var user =await _salerManager.FindByNameAsync(userName);
			inputDto.Id = user.Id;
			await UpdateSeller(inputDto, cancellationToken);

        }

		public async Task<GeneralSellerEditDto> GetByName(string userName,CancellationToken cancellationToken)
		{
            var user = await _salerManager.FindByNameAsync(userName);
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
	}
}

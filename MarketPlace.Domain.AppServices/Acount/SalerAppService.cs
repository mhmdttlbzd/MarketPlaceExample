using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
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
    public class SalerAppService : ISalerAppService
    {
		private readonly IMainAddressService _mainAddressService;
		private readonly ISalerService _salerService;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUnitOfWorks _unitOfWorks;
		private readonly IBoothService _boothService;

		public SalerAppService(IMainAddressService mainAddressService, ISalerService salerService, UserManager<ApplicationUser> userManager, IUnitOfWorks unitOfWorks, IBoothService boothService)
		{
			_mainAddressService = mainAddressService;
			_salerService = salerService;
			_userManager = userManager;
			_unitOfWorks = unitOfWorks;
			_boothService = boothService;
		}

		public async Task UpdateCustomer(GeneralSalerInputDto inputDto, CancellationToken cancellationToken)
		{
			var booth = await _boothService.GetByIdAsync(inputDto.Id, cancellationToken);
			int? addressId = booth.ShopAddressId;
			if (inputDto.CityId != -1)
			{
				addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);
				await _unitOfWorks.SaveChangesAsync(cancellationToken);
			}
			await _boothService.UpdateAsync(new BoothInputDto(inputDto.Id, inputDto.BoothName, addressId),inputDto.Id,cancellationToken);
			await _salerService.UpdateAsync(new SalerInputDto(inputDto.Id, inputDto.SalerTypeId), inputDto.Id, cancellationToken);
			var user = await _userManager.FindByIdAsync(inputDto.Id.ToString());
			user.Name = inputDto.Name;
			user.Family = inputDto.Family;
			user.Email = inputDto.Email;
			user.UserName = inputDto.Email;
			await _userManager.UpdateAsync(user);
		}
		public async Task<GeneralSalerEditDto> GetById(int id,CancellationToken cancellationToken)
		{
			var booth = await _boothService.GetByIdAsync(id, cancellationToken);
			var user = await _userManager.FindByIdAsync(id.ToString());
			var saler = new GeneralSalerEditDto
			{
				Id = user.Id,
				Name = user.Name,
				Family = user.Family,
				Email = user.Email,
				BoothName = booth.Name
			};

			return saler;
		}
	}
}

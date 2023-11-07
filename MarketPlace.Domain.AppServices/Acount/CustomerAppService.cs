using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IMainAddressService _mainAddressService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly UserManager<ApplicationUser> _userManager;

        public CustomerAppService(ICustomerService customerService, IMainAddressService mainAddressService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> userManager)
        {
            _customerService = customerService;
            _mainAddressService = mainAddressService;
            _unitOfWorks = unitOfWorks;
            _userManager = userManager;
        }

        public async Task UpdateCustomer(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken)
        {
            if (inputDto.CityId != -1)
            {
                int addressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);
                await _customerService.UpdateAsync(new CustomerInputDto(inputDto.Id, addressId), inputDto.Id, cancellationToken);
                await _unitOfWorks.SaveChangesAsync(cancellationToken);
            }
			var user = await _userManager.FindByIdAsync(inputDto.Id.ToString());
            user.Name = inputDto.Name;
            user.Family = inputDto.Family;
            user.Email = inputDto.Email;
            user.UserName = inputDto.Email;
            await _userManager.UpdateAsync(user);
        }
		public async Task<GeneralCustomerEditDto> GetById(int id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
            var customer = new GeneralCustomerEditDto
            {
                Id = user.Id,
                Name = user.Name,
                Family = user.Family,
                Email = user.Email
            };

			return customer;
		}
	}
}

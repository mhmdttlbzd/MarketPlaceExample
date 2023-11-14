using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
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
        private readonly UserManager<Customer> _customerManager;


        public CustomerAppService(ICustomerService customerService, IMainAddressService mainAddressService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> userManager, UserManager<Customer> customerManager)
        {
            _customerService = customerService;
            _mainAddressService = mainAddressService;
            _unitOfWorks = unitOfWorks;
            _userManager = userManager;
            _customerManager = customerManager;
        }

        public async Task UpdateCustomer(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken)
        {
			var customer = await _customerManager.FindByIdAsync(inputDto.Id.ToString());
            customer.Name = inputDto.Name;
            customer.Family = inputDto.Family;
            customer.Email = inputDto.Email;
            customer.UserName = inputDto.Email;
            var address = await _mainAddressService.GetByIdAsync(customer.AddressId, cancellationToken);
            if (inputDto.CityId != -1 || inputDto.CityId != address.CityId || inputDto.AddressDescription != address.Description)
            {
                customer.AddressId = await _mainAddressService.CreateAsync(new MainAddressInputDto(inputDto.CityId, inputDto.AddressDescription, inputDto.PostalCode), cancellationToken);
            }
            await _customerManager.UpdateAsync(customer);
        }
		public async Task<GeneralCustomerEditDto> GetById(int id , CancellationToken cancellationToken)
		{
			var customer = await _customerManager.FindByIdAsync(id.ToString());
            var address = await _mainAddressService.GetByIdAsync(customer.AddressId, cancellationToken);
            var res = new GeneralCustomerEditDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Family = customer.Family,
                Email = customer.Email,
                Address = address
            };

			return res;
		}
	}
}

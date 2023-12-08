using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Application.Enums;
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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IMainAddressService _mainAddressService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserManager<Customer> _customerManager;
        private readonly IOrderService _orderService;
        private readonly IOrderLineService _orderLineService;
        private readonly IWalletService _walletService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CustomerAppService(ICustomerService customerService, IMainAddressService mainAddressService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> userManager, UserManager<Customer> customerManager, IOrderService orderService, IOrderLineService orderLineService, IWalletService walletService, SignInManager<ApplicationUser> signInManager)
        {
            _customerService = customerService;
            _mainAddressService = mainAddressService;
            _unitOfWorks = unitOfWorks;
            _userManager = userManager;
            _customerManager = customerManager;
            _orderService = orderService;
            _orderLineService = orderLineService;
            _walletService = walletService;
            _signInManager = signInManager;
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



        public async Task<GeneralCustomerEditDto> GetById(int id, CancellationToken cancellationToken)
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

        public async Task<GeneralCustomerEditDto> GetByName(string userName, CancellationToken cancellationToken)
        {
            var user = await _customerManager.FindByNameAsync(userName);
            return await GetById(user.Id, cancellationToken);
        }

        public async Task<CustomerDto> GetDetails(string username, CancellationToken cancellationToken)
        {
            var customer = await _customerManager.FindByNameAsync(username);
            var address = await _mainAddressService.GetAddress(customer.AddressId, cancellationToken);
            var activeOrder = await _orderService.GetActiveOrder(customer.Id);
            var buyHistory = await _orderLineService.GetBuyHistory(customer.Id, cancellationToken);
            var balance = _walletService.GetMoneyByUserId(customer.Id);
            var res = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Family = customer.Family,
                Address = address.Address,
                CityName = address.CityName,
                ProvinsName = address.ProvinceName,
                PostalCode = address.PostalCode,
                ActiveOrder = activeOrder,
                BuyHistory = buyHistory,
                Email = customer.Email,
                Balance = balance
            };
            return res;
        }


        public async Task Deposit(string userName, long money)
        {
            var user = await _customerManager.FindByNameAsync(userName);
            await _walletService.Deposit(user.Id, money);
            _unitOfWorks.SaveChanges();
        }

        public async Task<bool> BuyCart(string userName)
        {
            var user = await _customerManager.FindByNameAsync(userName);
            var balance = _walletService.GetMoneyByUserId(user.Id);
            var order = await _orderService.GetActiveOrder(user.Id);
            long price = 0;
            foreach (var line in order.OrderLines)
            {
                price += line.Price;
            }
            if (balance >= price)
            {
                foreach (var line in order.OrderLines)
                {
                    await _walletService.AddTransaction(user.Id, line.SellerId, line.Price, SaleType.Order);
                }
                await _orderService.BuyOrder(order.Id);
                _unitOfWorks.SaveChanges();
                return true;
            }
            return false;
        }


        public async Task<Customer> Create(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken)
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
            await _userManager.AddToRoleAsync(customer, "Customer");
            await _walletService.CreateAsync(customer.Id);
            return customer;
        }
        public async Task Register(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken)
        {
            var customer = await Create(inputDto, cancellationToken);
            var claim = new Claim(ClaimTypes.Name, customer.UserName);
            await _userManager.AddClaimAsync(customer, claim);
            await _signInManager.PasswordSignInAsync(customer.UserName, inputDto.Password, true, true);
        }
    }
}

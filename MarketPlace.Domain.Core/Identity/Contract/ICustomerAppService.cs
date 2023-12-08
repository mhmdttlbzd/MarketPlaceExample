using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Contract
{
    public interface ICustomerAppService
    {
        Task UpdateCustomer(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken);
        Task<GeneralCustomerEditDto> GetById(int id,CancellationToken cancellationToken);
        Task<CustomerDto> GetDetails(string username, CancellationToken cancellationToken);
        Task Deposit(string userName, long money);
        Task<bool> BuyCart(string userName);
        Task<GeneralCustomerEditDto> GetByName(string userName, CancellationToken cancellationToken);
        Task<Customer> Create(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken);
        Task Register(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken);
    }
}

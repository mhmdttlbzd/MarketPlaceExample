using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Customer
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(CustomerInputDto input, CancellationToken cancellationToken);
        Task<List<CustomerOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CustomerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(CustomerInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int AllCustomersCount();
        Task<List<GeneralCustomerDto>> GetGeneralCustomers(CancellationToken cancellationToken);
    }
}

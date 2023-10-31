using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Contract.Services._Customer;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<int> CreateAsync(CustomerInputDto input, CancellationToken cancellationToken)
        {
            return await _customerRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _customerRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<CustomerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _customerRepo.GetAllAsync(cancellationToken);
        }

        public async Task<CustomerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _customerRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(CustomerInputDto input, int id, CancellationToken cancellationToken)
        {
           await UpdateAsync(input, id, cancellationToken);
        }
    }
}

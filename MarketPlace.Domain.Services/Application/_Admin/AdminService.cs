using MarketPlace.Domain.Core.Application.Contract.Repositories._Admin;
using MarketPlace.Domain.Core.Application.Contract.Services._Admin;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Admin
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepo _adminRepo;

        public AdminService(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<int> CreateAsync(AdminInputDto input, CancellationToken cancellationToken)
        {
            return await _adminRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _adminRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<AdminOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _adminRepo.GetAllAsync(cancellationToken);
        }

        public async Task<AdminOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _adminRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(AdminInputDto input, int id, CancellationToken cancellationToken)
        {
            await _adminRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}

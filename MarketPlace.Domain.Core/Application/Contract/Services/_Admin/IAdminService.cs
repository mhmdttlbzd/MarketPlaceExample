using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Admin
{
    public interface IAdminService
    {
        Task<int> CreateAsync(AdminInputDto input, CancellationToken cancellationToken);
        Task<List<AdminOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AdminOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AdminInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

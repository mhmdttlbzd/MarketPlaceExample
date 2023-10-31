using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Saler
{
    public interface ISalerService
    {
        Task<int> CreateAsync(SalerInputDto input, CancellationToken cancellationToken);
        Task<List<SalerOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SalerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(SalerInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

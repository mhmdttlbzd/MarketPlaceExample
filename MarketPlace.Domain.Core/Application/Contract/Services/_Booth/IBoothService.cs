using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Booth
{
    public interface IBoothService
    {
        Task<int> CreateAsync(BoothInputDto input, CancellationToken cancellationToken);
        Task<List<BoothOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<BoothOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(BoothInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<GeneralBoothDto> GetGeneralBoothById(int id, CancellationToken cancellationToken);
        List<GeneralBoothDto> GetByCategoryId(int id);
    }
}

using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Saler
{
    public interface ISalerTypeService
    {
        Task<List<SalerTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SalerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}

using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Saler
{
    public interface ISalerTypeRepo
    {
        Task<List<SalerTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SalerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}

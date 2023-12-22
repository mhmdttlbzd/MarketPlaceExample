using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Saler
{
    public interface ISalerTypeService
    {
        Task<List<SellerTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SellerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        int GetCount();

    }
}

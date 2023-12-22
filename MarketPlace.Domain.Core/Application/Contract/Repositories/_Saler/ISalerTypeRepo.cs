using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Saler
{
    public interface ISalerTypeRepo
    {
        Task<List<SellerTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SellerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        List<SellerTypeDto> GetAll();
        int GetCount();

    }
}

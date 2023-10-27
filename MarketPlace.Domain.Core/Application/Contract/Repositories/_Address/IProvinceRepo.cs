using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Address
{
    public interface IProvinceRepo
    {
        Task<List<ProvinceDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProvinceDto> GetByIdAsync(int id,CancellationToken cancellationToken);
    }
}

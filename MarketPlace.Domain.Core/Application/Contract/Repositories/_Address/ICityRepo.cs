using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Address
{
    public interface ICityRepo
    {
        Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CityDto> GetByIdAsync(int id,CancellationToken cancellationToken);
        Task<List<CityDto>> GetByProvinceId(int id);
    }
}

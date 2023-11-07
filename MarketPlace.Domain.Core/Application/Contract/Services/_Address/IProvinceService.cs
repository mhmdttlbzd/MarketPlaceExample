using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Address
{
    public interface IProvinceService
    {
        Task<List<ProvinceDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProvinceDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        List<ProvinceDto> GetAll();
    }
}

using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Booth
{
    public interface IBoothProductService
    {
        Task<int> CreateAsync(BoothProductInputDto input, CancellationToken cancellationToken);
        Task<List<BoothProductOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<BoothProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(BoothProductInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

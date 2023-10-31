using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Booth
{
    public interface IBoothProductsPriceService
    {
        Task<int> CreateAsync(BoothProductsPriceInputDto input, CancellationToken cancellationToken);
        Task<List<BoothProductsPriceOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<BoothProductsPriceOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(BoothProductsPriceInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

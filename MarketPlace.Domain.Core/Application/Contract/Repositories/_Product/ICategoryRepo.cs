using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Product
{
    public interface ICategoryRepo
    {
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetByIdAsync(int id,CancellationToken cancellationToken);
        List<CategoryDto> GetAll();
    }
}

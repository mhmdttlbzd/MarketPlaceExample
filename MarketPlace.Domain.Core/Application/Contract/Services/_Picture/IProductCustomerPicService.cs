using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Picture
{
    public interface IProductCustomerPicService
    {
        Task<int> CreateAsync(ProductCustomerPicInputDto input, CancellationToken cancellationToken);
        Task<List<ProductCustomerPicOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductCustomerPicOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(ProductCustomerPicInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int GetRequestsCount();
        Task ConfirmAsync(int id, CancellationToken cancellationToken);
        Task FaleAsync(int id, CancellationToken cancellationToken);
        Task<List<CustomerPicRequestDto>> GetRequests(CancellationToken cancellationToken);

    }
}

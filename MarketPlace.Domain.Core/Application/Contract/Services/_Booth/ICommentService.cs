using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Booth
{
    public interface ICommentService
    {
        int GetCount();
        Task<int> CreateAsync(CommentInputDto input, CancellationToken cancellationToken);
        Task<List<CommentOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CommentOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(CommentInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int GetRequestsCount();
        Task ConfirmAsync(int id, CancellationToken cancellationToken);
        Task FaleAsync(int id, CancellationToken cancellationToken);
        Task<List<CommentRequestDto>> GetRequests(CancellationToken cancellationToken);
    }
}

using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Booth
{
    public interface ICommentService
    {
        Task<int> CreateAsync(CommentInputDto input, CancellationToken cancellationToken);
        Task<List<CommentOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CommentOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(CommentInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

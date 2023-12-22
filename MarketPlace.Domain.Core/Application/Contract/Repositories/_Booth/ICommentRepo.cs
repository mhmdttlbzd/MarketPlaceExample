using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Booth
{
    public interface ICommentRepo : IBaseCrudRepository<Comment, CommentInputDto, CommentOutputDto>
    {
		int GetRequestsCount();
        Task ConfirmAsync(int id, CancellationToken cancellationToken);
        Task FaleAsync(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<List<CommentRequestDto>> GetRequests(CancellationToken cancellationToken);
    }
}

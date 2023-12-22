using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Booth
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }
        public int GetCount() => _commentRepo.GetCount();


        public async Task<int> CreateAsync(CommentInputDto input, CancellationToken cancellationToken)
        =>await _commentRepo.CreateAsync(input, cancellationToken);
        

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        => await _commentRepo.DeleteAsync(id, cancellationToken);


        public async Task<List<CommentOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        => await _commentRepo.GetAllAsync(cancellationToken);


        public async Task<CommentOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _commentRepo.GetByIdAsync(id, cancellationToken);


        public async Task UpdateAsync(CommentInputDto input, int id, CancellationToken cancellationToken)
            =>await _commentRepo.UpdateAsync(input, id, cancellationToken);


        public int GetRequestsCount() => _commentRepo.GetRequestsCount();

        public async Task<List<CommentRequestDto>> GetRequests(CancellationToken cancellationToken)
             => await _commentRepo.GetRequests(cancellationToken);


        public async Task ConfirmAsync(int id, CancellationToken cancellationToken) => await _commentRepo.ConfirmAsync(id, cancellationToken);
        public async Task FaleAsync(int id, CancellationToken cancellationToken) => await _commentRepo.FaleAsync(id, cancellationToken);

    }
}

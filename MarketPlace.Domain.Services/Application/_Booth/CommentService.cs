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

        public async Task<int> CreateAsync(CommentInputDto input, CancellationToken cancellationToken)
        {
            return await _commentRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _commentRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<CommentOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _commentRepo.GetAllAsync(cancellationToken);
        }

        public async Task<CommentOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _commentRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(CommentInputDto input, int id, CancellationToken cancellationToken)
        {
            await _commentRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}

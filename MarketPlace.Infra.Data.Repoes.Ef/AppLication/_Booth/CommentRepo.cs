using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class CommentRepo : BaseEntityCrudRepository<Comment,
CommentInputDto, CommentOutputDto>, ICommentRepo
    {
        public CommentRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public async override Task UpdateAsync(CommentInputDto input, int id, CancellationToken cancellationToken)
        {
             var comment = await _dbContext.Set<Comment>().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if(comment != null)
            {
                comment.Description = input.Description;
                comment.Satisfaction = input.Satisfaction;
            }
        }

        public int GetRequestsCount()
            => _dbContext.Set<Comment>().Where(c => c.Status == GeneralStatus.AwaitConfirmation).Count();

        public async Task<List<CommentRequestDto>> GetRequests(CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Set<Comment>().Where(p => p.Status == GeneralStatus.AwaitConfirmation)
                .Select(selector: c => new CommentRequestDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    ProductName = c.BoothProduct.Product.Name,
                    BoothName = c.BoothProduct.Booth.Name,
                    CustomerId = c.CustomerId
                })
                .AsNoTracking().ToListAsync(cancellationToken);
            return comments;
        }


        public async Task ConfirmAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<Comment>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Confirmed;
        }
        public async Task FaleAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<Comment>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Failed;
        }


    }
}

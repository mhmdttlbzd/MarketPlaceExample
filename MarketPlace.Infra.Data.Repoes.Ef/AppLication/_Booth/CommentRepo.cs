using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class CommentRepo : BaseEntityCrudRepository<Comment,
CommentInputDto, CommentOutputDto>, ICommentRepo
    {
        public CommentRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public int GetRequestsCount()
            => _dbContext.Set<Comment>().Where(c => c.Status == GeneralStatus.AwaitConfirmation).Count();
        
    }
}

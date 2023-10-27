using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class CommentRepo : BaseEntityCrudRepository<Comment,
CommentInputDto, CommentOutputDto>, ICommentRepo
    {
        public CommentRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

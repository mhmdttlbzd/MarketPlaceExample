using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Infra.Db.SqlServer.Ef;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture
{
    public class AuctionPictureRepo : BaseEntityCrudRepository<AuctionPicture,
AuctionPictureInputDto, AuctionPictureOutputDto>, IAuctionPictureRepo
    {
        public AuctionPictureRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

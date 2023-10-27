using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IAuctionPictureRepo : IBaseCrudRepository<AuctionPicture, AuctionPictureInputDto, AuctionPictureOutputDto>
    {

    }
}

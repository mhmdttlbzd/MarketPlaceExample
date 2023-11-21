using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Auction
{
    public interface IAuctionRepo : IBaseCrudRepository<Auction, AuctionInputDto, AuctionOutputDto>
    {
        List<GeneralAuctionDto> GetGeneralAuctionBySellerId(int sellerId);
    }
}

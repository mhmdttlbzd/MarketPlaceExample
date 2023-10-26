
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Action
    public record AuctionOutputDto(
        int Id, int BootId, DateTime ExpiredTime, int Quantity, int ProductId, ProductOutputDto Product,
        ICollection<AuctionProposalOutputDto> ActionProposals,ICollection<AuctionPictureOutputDto> PicturesActions
        );
    public record AuctionInputDto(
         int BootId, DateTime ExpiredTime, int Quantity, int ProductId
        );
    #endregion

    #region ActionProposal
    public record AuctionProposalOutputDto(
        int Id ,int AuctionId,long Price,int CustomerId,AuctionOutputDto Auction,CustomerOutputDto Customer
        );

    public record AuctionProposalInputDto(
        int AuctionId, long Price, int CustomerId
        );
    #endregion
}


using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Auction
    public record AuctionOutputDto(
        int Id, int BootId, DateTime ExpiredTime, int Quantity, int ProductId, ProductOutputDto Product,
        ICollection<AuctionProposalOutputDto> ActionProposals,ICollection<AuctionPictureOutputDto> PicturesActions
        );
    public record AuctionInputDto(
         int BoothId, DateTime ExpiredTime,  int ProductId,long BasePrice,string Description
        );


    public record GeneralAuctionDto
    {
        public int Id { get; set; }
        public string PicturePath { get; set; }
        public string PictureAlt { get; set; }
        public string ProductName { get; set; }
        public long LastPrice { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string Description { get; set; }
    }

    public record AuctionModel
    {
        public int ProductId { get; set; }
        public int ExpireDay { get; set; }
        public long BasePrice { get; set; }
        public string Description { get; set; }
    }
    #endregion

    #region ActionProposal
    public record AuctionProposalOutputDto(
        int Id ,int AuctionId,long Price,int CustomerId,AuctionOutputDto Auction,CustomerOutputDto Customer
        );

    public record AuctionProposalInputDto(
        int AuctionId, long Price, int CustomerId
        );

    public record AuctionProposalDto
    {
        public long Price { get; set; }
        public int CustomerId { get; set; }
    }
    #endregion
}

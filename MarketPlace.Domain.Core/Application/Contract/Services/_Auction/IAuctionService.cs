using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Auction
{
    public interface IAuctionService
    {
        Task<int> CreateAsync(AuctionInputDto input, CancellationToken cancellationToken);
        Task<List<AuctionOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AuctionOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AuctionInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        List<GeneralAuctionDto> GetGeneralAuctionBySellerId(int sellerId);

        List<GeneralAuctionDto> GetThreeBestAuctions();
        List<GeneralAuctionDto> GetThreeBestAuctions(int sellerId);
        List<GeneralAuctionDto> GetTowNewAuctions();
    }
}

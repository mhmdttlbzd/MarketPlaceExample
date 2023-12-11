using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface IAuctionAppService
    {
        Task Create(List<string> paths, AuctionModel model, CancellationToken cancellationToken, string username);
        Task PickWinner(int auctionId, int sellerId);
        List<GeneralAuctionDto> GetThreeBestAuctions(int? sellerId = null);
        List<GeneralAuctionDto> GetTowNewAuctions();
        Task<AuctionOutputDto> GetById(int id, CancellationToken cancellationToken);
        Task CreateProposal(string userName, int auctionId, long price, CancellationToken cancellationToken);
        Task DeleteAuction(int id, CancellationToken cancellationToken);
    }
}

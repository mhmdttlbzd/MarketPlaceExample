using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Auction
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepo _auctionRepo;
        private readonly IAuctionProposalRepo _auctionProposalRepo;

        public AuctionService(IAuctionRepo auctionRepo, IAuctionProposalRepo auctionProposalRepo)
        {
            _auctionRepo = auctionRepo;
            _auctionProposalRepo = auctionProposalRepo;
        }
        public int GetCount() => _auctionRepo.GetCount();
        public async Task<int> CreateAsync(AuctionInputDto input, CancellationToken cancellationToken)
        {
            return await _auctionRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _auctionRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<AuctionOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _auctionRepo.GetAllAsync(cancellationToken);
        }

        public async Task<AuctionOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var auction = await _auctionRepo.GetByIdAsync(id, cancellationToken);
            if (_auctionProposalRepo.GetProposalCountByActionId(auction.Id) != 0)
            {
                auction.LastPrice = _auctionProposalRepo.GetLastProposalPrice(auction.Id);
            }
            return auction;
        }

        public async Task UpdateAsync(AuctionInputDto input, int id, CancellationToken cancellationToken)
        {
            await _auctionRepo.UpdateAsync(input, id, cancellationToken);
        }

        private void UpdateLastPrice(ref List<GeneralAuctionDto> auctions)
        {
            foreach (var auction in auctions)
            {
                if (_auctionProposalRepo.GetProposalCountByActionId(auction.Id) != 0)
                {
                    auction.LastPrice = _auctionProposalRepo.GetLastProposalPrice(auction.Id);
                }
            }
        }

        public List<GeneralAuctionDto> GetGeneralAuctionBySellerId(int sellerId)
        {
            var auctions =  _auctionRepo.GetGeneralAuctionBySellerId(sellerId);
            UpdateLastPrice(ref auctions);
            return auctions;
        }

        public List<GeneralAuctionDto> GetThreeBestAuctions()
        {
            var auctions = _auctionRepo.GetThreeBestAuctions();
            UpdateLastPrice(ref auctions);
            return auctions;
        }
        public List<GeneralAuctionDto> GetThreeBestAuctions(int sellerId)
        {
            var auctions = _auctionRepo.GetThreeBestAuctions( sellerId);
            UpdateLastPrice(ref auctions);
            return auctions;
        }

        public List<GeneralAuctionDto> GetTowNewAuctions()
        {
            var auctions = _auctionRepo.GetTowNewAuctions();
            UpdateLastPrice(ref auctions);
            return auctions;
        }
    }
}

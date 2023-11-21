using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Dtos;
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
            return await _auctionRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(AuctionInputDto input, int id, CancellationToken cancellationToken)
        {
            await _auctionRepo.UpdateAsync(input, id, cancellationToken);
        }
        public List<GeneralAuctionDto> GetGeneralAuctionBySellerId(int sellerId)
        {
            var auctions =  _auctionRepo.GetGeneralAuctionBySellerId(sellerId);
            foreach (var auction in auctions)
            {
                if (_auctionProposalRepo.GetProposalCountByActionId(auction.Id) != 0)
                {
                    auction.LastPrice = _auctionProposalRepo.GetLastProposalPrice(auction.Id);
                }
            }
            return auctions;
        }
    }
}

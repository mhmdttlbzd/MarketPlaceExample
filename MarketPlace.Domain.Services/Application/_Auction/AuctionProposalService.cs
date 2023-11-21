using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Auction
{
    public class AuctionProposalService : IAuctionProposalService
    {
        private readonly IAuctionProposalRepo _auctionProposalRepo;

        public AuctionProposalService(IAuctionProposalRepo auctionProposalRepo)
        {
            _auctionProposalRepo = auctionProposalRepo;
        }

        public async Task<int> CreateAsync(AuctionProposalInputDto input, CancellationToken cancellationToken)
        {
            return await _auctionProposalRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _auctionProposalRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<AuctionProposalOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _auctionProposalRepo.GetAllAsync(cancellationToken);
        }

        public async Task<AuctionProposalOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _auctionProposalRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(AuctionProposalInputDto input, int id, CancellationToken cancellationToken)
        {
            await _auctionProposalRepo.UpdateAsync(input, id, cancellationToken);
        }
        public List<AuctionProposalDto> GetProposalsByAuctionId(int auctionId)
            => _auctionProposalRepo.GetProposalsByAuctionId(auctionId);
    }
}

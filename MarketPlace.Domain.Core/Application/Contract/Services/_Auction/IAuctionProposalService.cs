using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Auction
{
    public interface IAuctionProposalService
    {
        Task<int> CreateAsync(AuctionProposalInputDto input, CancellationToken cancellationToken);
        Task<List<AuctionProposalOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AuctionProposalOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AuctionProposalInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        List<AuctionProposalDto> GetProposalsByAuctionId(int auctionId);
    }
}

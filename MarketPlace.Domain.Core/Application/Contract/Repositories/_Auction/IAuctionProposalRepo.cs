using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions
{
    public interface IAuctionProposalRepo : IBaseCrudRepository<AuctionProposal, AuctionProposalInputDto, AuctionProposalOutputDto>
    {
    }
}

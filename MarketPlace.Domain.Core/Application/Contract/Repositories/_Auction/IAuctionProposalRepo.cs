﻿using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions
{
    public interface IAuctionProposalRepo : IBaseCrudRepository<AuctionProposal, AuctionProposalInputDto, AuctionProposalOutputDto>
    {
        int GetProposalCountByActionId(int auctionId);
        long GetLastProposalPrice(int auctionId);
        List<AuctionProposalDto> GetProposalsByAuctionId(int auctionId);
    }
}

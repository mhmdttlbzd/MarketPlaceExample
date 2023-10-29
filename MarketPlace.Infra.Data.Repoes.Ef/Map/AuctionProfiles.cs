using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class AuctionProfiles : Profile
    {
        public AuctionProfiles()
        {
            CreateMap<Auction, AuctionOutputDto>();
            CreateMap<Auction, AuctionInputDto>();

            CreateMap<AuctionProposal, AuctionProposalOutputDto>();
            CreateMap<AuctionProposal, AuctionProposalInputDto>();
        }
    }
}

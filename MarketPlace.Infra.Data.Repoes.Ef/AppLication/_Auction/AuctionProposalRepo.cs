using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Infra.Db.SqlServer.Ef;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Auction
{
    public class AuctionProposalRepo : BaseEntityCrudRepository<AuctionProposal,
AuctionProposalInputDto, AuctionProposalOutputDto>, IAuctionProposalRepo
    {
        public AuctionProposalRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

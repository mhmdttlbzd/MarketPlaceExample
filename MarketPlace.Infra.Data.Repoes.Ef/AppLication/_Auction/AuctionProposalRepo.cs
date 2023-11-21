using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auctions;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Infra.Db.SqlServer.Ef;
using System.Data.Entity;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Auction
{
    public class AuctionProposalRepo : BaseEntityCrudRepository<AuctionProposal,
AuctionProposalInputDto, AuctionProposalOutputDto>, IAuctionProposalRepo
    {
        public AuctionProposalRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
        public int GetProposalCountByActionId(int auctionId)
           =>  _dbContext.Set<AuctionProposal>().Where(p => p.AuctionId == auctionId && p.IsDeleted != true).Count();

        public long GetLastProposalPrice(int auctionId)
        {
            var res =  _dbContext.Set<AuctionProposal>().Where(p => p.AuctionId == auctionId).OrderBy(p => p.Price).AsNoTracking().LastOrDefault();
            return res.Price;
        }
        
        public List<AuctionProposalDto> GetProposalsByAuctionId(int auctionId)
            => _dbContext.Set<AuctionProposal>().Where(p => p.AuctionId == auctionId && p.IsDeleted != true).Select(p => new AuctionProposalDto
            {
                CustomerId = p.CustomerId,
                Price = p.Price
            }).AsNoTracking().ToList();
    }
}

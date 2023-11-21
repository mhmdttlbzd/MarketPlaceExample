using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Auction
{
    public class AuctionRepo : BaseEntityCrudRepository<Auction,
    AuctionInputDto, AuctionOutputDto>, IAuctionRepo
    {
        public AuctionRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
        public List<GeneralAuctionDto> GetGeneralAuctionBySellerId(int sellerId)
        {
            var res =  _dbContext.Set<Auction>()
                .Where(a => a.BoothId == sellerId && a.ExpiredTime > DateTime.Now && a.IsDeleted != true).Select(a => new GeneralAuctionDto
            {
                Id = a.Id,
                PicturePath = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                PictureAlt = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                ProductName = a.Product.Name,
                Description = a.Description,
                ExpiredTime = a.ExpiredTime,
                LastPrice = a.BasePrice
            }).AsNoTracking().ToList();
            return res;
        }
    }
}

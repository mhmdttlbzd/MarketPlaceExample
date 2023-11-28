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
        public async override Task<AuctionOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            var res = _dbContext.Set<Auction>().Where(a => a.Id == Id).Select(a => new AuctionOutputDto
            {
                Id = a.Id,
                pictures = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed && p.IsDeleted != true).Select(p => new PictureDto
                {
                    Id = p.Id,
                    Path = p.Picture.Path,
                    Alt = p.Picture.Alt
                }).ToList(),
                ProductName = a.Product.Name,
                LastPrice = a.BasePrice,
                Description = a.Description,
                ExpiredTime = a.ExpiredTime
            }).FirstOrDefault();
            return res;
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
        public List<GeneralAuctionDto> GetThreeBestAuctions()
        {
           var res =  _dbContext.Set<Auction>()
                .Where(a => a.ExpiredTime > DateTime.Now && a.IsDeleted != true).Select(a => new GeneralAuctionDto
            {
                Id = a.Id,
                PicturePath = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                PictureAlt = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                ProductName = a.Product.Name,
                Description = a.Description,
                ExpiredTime = a.ExpiredTime,
                LastPrice = a.BasePrice
            }).AsNoTracking().Skip(1).Take(3).ToList();
            return res;
        }
        public List<GeneralAuctionDto>  GetThreeBestAuctions(int sellerId)
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
            }).AsNoTracking().Take(3).ToList();
            return res;
        }

        public  List<GeneralAuctionDto> GetTowNewAuctions()
        {
            var res =  _dbContext.Set<Auction>()
                .Where(a => a.ExpiredTime > DateTime.Now && a.IsDeleted != true).Select(a => new GeneralAuctionDto
            {
                Id = a.Id,
                PicturePath = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                PictureAlt = a.PicturesActions.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                ProductName = a.Product.Name,
                Description = a.Description,
                ExpiredTime = a.ExpiredTime,
                LastPrice = a.BasePrice
            }).AsNoTracking().OrderBy(a => a.ExpiredTime).Take(2).ToList();
            return res;
        }
    }
}

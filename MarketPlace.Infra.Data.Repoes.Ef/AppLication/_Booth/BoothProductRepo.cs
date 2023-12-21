using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class BoothProductRepo : BaseEntityCrudRepository<BoothProduct,
BoothProductInputDto, BoothProductOutputDto>, IBoothProductRepo
    {
        public BoothProductRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
        public override async Task UpdateAsync(BoothProductInputDto input, int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<BoothProduct>().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            if (product != null)
            {
                product.Quantity = input.Quantity;
            }
        }


        public async override Task<BoothProductOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            var res = _dbContext.Set<BoothProduct>().Where(b => b.Id == Id).Select(b => new BoothProductOutputDto
            {
                Id = b.Id,
                Pictures = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed && p.IsDeleted != true).Select(p => new PictureDto
                {
                    Path = p.Picture.Path,
                    Id = p.Id,
                    Alt = p.Picture.Alt
                }).ToList(),
                CustomerPictures = b.CustomersProductPices.Where(p => p.Status == GeneralStatus.Confirmed && p.IsDeleted != true).Select(p => new PictureDto
                {
                    Path = p.Picture.Path,
                    Id = p.Id,
                    Alt = p.Picture.Alt
                }).ToList(),
                Price = b.BoothProductsPrices.Where(p => p.ToDate == null || p.ToDate > DateTime.Now).OrderBy(p => p.FromDate).LastOrDefault().Price,
                ProductName = b.Product.Name,
                BoothId = b.BoothId,
                Quantity = b.Quantity,
                Buyers = b.OrderLines.Select(o => o.Order).Where(o => o.Status == OrderStatus.Bought).Select(o => o.Customer.UserName).ToList(),
                Comments = b.Comments.Select(c => new CommentDto
                {
                    CustomerName = c.Customer.Name,
                    Description = c.Description,
                    Satisfaction = c.Satisfaction
                }).ToList(),
                Attributes = b.Product.ProductsCustomAttributes.Select(a => new ProductAttrOutModel
                {
                    Id = a.Id,
                    AttributeName = a.Attribute.Title,
                    AttributeValue = a.AttributeValue
                }).ToList()
            }).FirstOrDefault();
            return res;
        }

        public List<GeneralBoothProductDto> GetBestProducts(int Count)
        {
            var res = _dbContext.Set<BoothProduct>().OrderBy(b => b.OrderLines.Count()).Reverse().Select(b => new GeneralBoothProductDto
            {
                Id = b.Id,
                PictureAlt = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                PicturePath = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                Price = b.BoothProductsPrices.Where(p => p.ToDate == null || p.ToDate > DateTime.Now).OrderBy(p => p.FromDate).LastOrDefault().Price,
                ProductName = b.Product.Name
            }).Take(Count).ToList();
            return res;
        }
        public List<GeneralBoothProductDto> GetSellerProducts(int sellerId)
        {
            var res = _dbContext.Set<BoothProduct>().Where(b => b.BoothId == sellerId && b.IsDeleted != true).OrderBy(b => b.OrderLines.Count()).Select(b => new GeneralBoothProductDto
            {
                Id = b.Id,
                PictureAlt = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                PicturePath = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                Price = b.BoothProductsPrices.Where(p => p.ToDate == null || p.ToDate > DateTime.Now).OrderBy(p => p.FromDate).LastOrDefault().Price,
                ProductName = b.Product.Name
            }).ToList();
            return res;
        }

        public List<GeneralBoothProductDto> GetByCategoryId(int id)
        {
            var res = _dbContext.Set<BoothProduct>().Where(p => p.Product.CategoryId == id).Select(b => new GeneralBoothProductDto
            {
                Id = b.Id,
                PictureAlt = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Alt,
                PicturePath = b.SalersProductPics.Where(p => p.Status == GeneralStatus.Confirmed).FirstOrDefault().Picture.Path,
                Price = b.BoothProductsPrices.Where(p => p.ToDate == null || p.ToDate > DateTime.Now).OrderBy(p => p.FromDate).LastOrDefault().Price,
                ProductName = b.Product.Name
            }).ToList();
            return res;
        }
    }
}

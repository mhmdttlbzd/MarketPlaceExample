using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture
{
    public class ProductCustomerPicRepo : BaseEntityCrudRepository<ProductCustomerPic,
ProductCustomerPicInputDto, ProductCustomerPicOutputDto>, IProductCustomerPicRepo
    {
        public ProductCustomerPicRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
		public int GetRequestsCount()
	=> _dbContext.Set<ProductCustomerPic>().Where(c => c.Status == GeneralStatus.AwaitConfirmation).Count();

        public async Task<List<CustomerPicRequestDto>> GetRequests(CancellationToken cancellationToken)
        {

            var pictures = await _dbContext.Set<ProductCustomerPic>().Where(p => p.Status == GeneralStatus.AwaitConfirmation)
                .Select(p => new CustomerPicRequestDto
                {
                    Id = p.Id,
                    Path = p.Picture.Path,
                    ProductName = p.BoothProduct.Product.Name,
                    CustomerId = p.CustomerId
                })
                .AsNoTracking().ToListAsync(cancellationToken);
            return pictures;
        }
        public async Task ConfirmAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<ProductCustomerPic>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Confirmed;
        }
        public async Task FaleAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<ProductCustomerPic>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Failed;
        }
    }
}

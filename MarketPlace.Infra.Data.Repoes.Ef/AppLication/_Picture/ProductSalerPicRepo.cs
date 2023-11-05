using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture
{
    public class ProductSalerPicRepo : BaseEntityCrudRepository<ProductSalerPic,
ProductSalerPicInputDto, ProductSalerPicOutputDto>, IProductSalerPicRepo
    {
        public ProductSalerPicRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
		public int GetRequestsCount()
	=> _dbContext.Set<ProductSalerPic>().Where(c => c.Status == GeneralStatus.AwaitConfirmation).Count();


		public async Task<List<SalerPicRequestDto>> GetRequests(CancellationToken cancellationToken)
		{

			var pictures = await _dbContext.Set<ProductSalerPic>().Where(p => p.Status == GeneralStatus.AwaitConfirmation)
				.Select(p => new SalerPicRequestDto
				{
					Id = p.Id,
					Path = p.Picture.Path,
					ProductName = p.BoothProduct.Product.Name
				})
				.AsNoTracking().ToListAsync(cancellationToken);
			return pictures;
		}
		public async Task ConfirmAsync(int id, CancellationToken cancellationToken)
		{
			var product = await _dbContext.Set<ProductSalerPic>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
			product.Status = GeneralStatus.Confirmed;
		}
		public async Task FaleAsync(int id, CancellationToken cancellationToken)
		{
			var product = await _dbContext.Set<ProductSalerPic>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
			product.Status = GeneralStatus.Failed;
		}
	}
}

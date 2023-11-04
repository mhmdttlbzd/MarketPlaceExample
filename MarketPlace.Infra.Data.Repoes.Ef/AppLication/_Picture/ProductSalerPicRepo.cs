using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;

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

	}
}

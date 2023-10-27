using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._CustomAttribute
{
    public class ProductAttributeRepo : BaseEntityCrudRepository<ProductsCustomAttribute,
        ProductAttributeOutputDto, ProductAttributeInputDto>, IProductAttributeRepo
    {
        public ProductAttributeRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

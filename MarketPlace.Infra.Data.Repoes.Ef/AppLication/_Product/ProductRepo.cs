using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Product
{
    public class ProductRepo : BaseEntityCrudRepository<Product,
    ProductInputDto, ProductOutputDto>, IProductRepo
    {
        public ProductRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            
        }
        public int GetCount() => _dbContext.Set<Product>().Count();
        public int AllRequestsCount() => _dbContext.Set<Product>().Where(p => p.Status == GeneralStatus.AwaitConfirmation).Count();
    }
}

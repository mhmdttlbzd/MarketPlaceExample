using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;
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
    }
}

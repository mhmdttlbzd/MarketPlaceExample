using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
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
        public async override Task UpdateAsync(ProductInputDto input, int id, CancellationToken cancellationToken)
        {
            var product =  await _dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Name = input.Name;
            product.CategoryId = input.CategoryId;
        }

        public async override Task<ProductOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Product>().Where(p => p.Id == Id).Select(p => new ProductOutputDto
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                attributes = p.ProductsCustomAttributes.Select(a => new ProductAttrOutModel
                {
                    Id = a.Id,
                    AttributeValue = a.AttributeValue,
                    AttributeName = a.Attribute.Title
                }).ToList()
            }).AsNoTracking().FirstAsync(cancellationToken);
        }


        public int GetCount() => _dbContext.Set<Product>().Count();
        public int AllRequestsCount() => _dbContext.Set<Product>().Where(p => p.Status == GeneralStatus.AwaitConfirmation).Count();
        public async Task<List<ProductRequestDto>> GetRequests(CancellationToken cancellationToken)
        {

            var products = await _dbContext.Set<Product>().Where(p => p.Status == GeneralStatus.AwaitConfirmation)
                .Include(p => p.Category)
                .Select(selector: p => new ProductRequestDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CategoryTitle = p.Category.Title
                })
                .AsNoTracking().ToListAsync(cancellationToken);
            return products;
        }
        public async Task ConfirmAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Confirmed;
        }
        public async Task FaleAsync(int id, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            product.Status = GeneralStatus.Failed;
        }
    }
}

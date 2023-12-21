using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class BoothProductsPriceRepo : IBoothProductsPriceRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;

        public BoothProductsPriceRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> CreateAsync(BoothProductsPriceInputDto input, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<BoothProductsPrice>(input);
            var res = await _dbContext.Set<BoothProductsPrice>().AddAsync(entity, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
            return res.Entity.Id;
        }

        public async Task Teminate(int id)
        {
            var price = await _dbContext.Set<BoothProductsPrice>().Where(p => p.Id == id).FirstOrDefaultAsync();
            price.ToDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        public int GetLastPriceIdByProductId(int productId)
        {
            var res = _dbContext.Set<BoothProductsPrice>().Where(p => p.BoothProductId == productId && (p.ToDate == null || p.ToDate > DateTime.Now)).OrderBy(p => p.FromDate).Last().Id;
            return res;
        }

        public List<ProductPriceDto> GetPricesByProductId(int productId)
        {
            var res = _dbContext.Set<BoothProductsPrice>().Where(p => p.BoothProductId == productId).Select(p => new ProductPriceDto
            {
                FromDate = p.FromDate,
                Price = p.Price
            }).AsNoTracking().OrderBy(p => p.FromDate).ToList();
            return res;
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoothProductsPriceOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BoothProductsPriceOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BoothProductsPriceInputDto input, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

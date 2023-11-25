using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Saler
{
    public class SalerRepo : ISalerRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Saler> _entities;
        public SalerRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Saler>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(SellerInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Seller>(InputDto);
            await _dbContext.Set<Seller>().AddAsync(entity, cancellationToken);
           
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Seller>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Seller>().Remove(entity);

        }
        public async Task UpdateType(int sellerId,int sellerTypeId)
        {
            var seller = await _dbContext.Set<Seller>().FirstOrDefaultAsync(s => s.Id == sellerId);
            seller.SellerTypeId = sellerTypeId;
        }
         

        public Task<SellerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SellerInputDto input, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SellerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<SellerOutputDto>>(await _dbContext.Set<Seller>().ToListAsync());


        public int AllSellersCount() => _dbContext.Set<Seller>().Count();

        public async Task<List<GeneralSellerDto>> GetGeneralSalers(CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Seller>().Select(c => new GeneralSellerDto
            {
                Id = c.Id,
                CityName = c.Booth.ShopAddress.City.Name,
                ProvinsName = c.Booth.ShopAddress.City.Province.Name,
                BoothName = c.Booth.Name,
                SellerTypeName = c.SellerType.Title
            }).ToListAsync();
        }

        public byte GetWagePercent(int sellerId)
            =>  _dbContext.Set<Seller>().Where(s => s.Id == sellerId).Select(s => s.SellerType.WagePercent).FirstOrDefault();


    }
}

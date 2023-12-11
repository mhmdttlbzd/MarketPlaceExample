using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;


namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class BoothRepo : IBoothRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Booth> _entities;
        public BoothRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Booth>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(BoothInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(InputDto);
            await _dbContext.Set<Booth>().AddAsync(entity, cancellationToken);

            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Booth>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Booth>().Remove(entity);

        }


        public async Task<List<BoothOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<BoothOutputDto>>(await _dbContext.Set<Booth>().ToListAsync(cancellationToken));



        public async Task<BoothOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var booth = await _dbContext.Set<Booth>().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            return new BoothOutputDto(booth.Id, booth.Name, (int)booth.ShopAddressId, null, null, null);
        }

        public async Task<long> GetSalesMoney(int sellerId)
        {
            return await _dbContext.Set<Booth>().Where(b => b.Id == sellerId).Select(b => b.SalesMoney).FirstOrDefaultAsync();
        }

        public async Task<GeneralBoothDto> GetGeneralBoothById(int id, CancellationToken cancellationToken)
        {
            var res = await _dbContext.Set<Booth>().Where(b => b.Id == id).Select(b => new GeneralBoothDto
            {
                Id = b.Id,
                Name = b.Name,
                CityName = b.ShopAddress.City.Name,
                Address = b.ShopAddress.Address,
                PostalCode = b.ShopAddress.PostalCode,
                TotalSales = b.SalesMoney,
                BoothProductsCount = b.BoothsProducts.Count()
            }).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return res;
        }

        public List<GeneralBoothDto> GetByCategoryId(int id)
        {
            var ids = _dbContext.Set<BoothProduct>().Where(b => b.Product.CategoryId == id && b.IsDeleted!=true).Select(b => b.BoothId).ToList();
            var setInts = new HashSet<int>();
            foreach (var i in ids)
            {
                setInts.Add(i);
            }
            var res = new List<GeneralBoothDto>();
            foreach (var i in setInts)
            {
                var r = _dbContext.Set<Booth>().Where(b => b.Id == i).Select(b => new GeneralBoothDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    CityName = b.ShopAddress.City.Name,
                    Address = b.ShopAddress.Address,
                    PostalCode = b.ShopAddress.PostalCode,
                    TotalSales = b.SalesMoney,
                    BoothProductsCount = b.BoothsProducts.Count()
                }).FirstOrDefault();

                res.Add(r);
            }
            return res;
        }
        public async Task UpdateAsync(BoothInputDto input, int id, CancellationToken cancellationToken)
        {
            var booth = await _dbContext.Set<Booth>().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            booth.Name = input.Name;
            booth.ShopAddressId = input.ShopAddressId;
        }
    }
}

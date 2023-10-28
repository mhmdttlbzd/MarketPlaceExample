using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Address
{
    public class ProvinceRepo : IProvinceRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        private readonly DbSet<Province> _entities;

        public ProvinceRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<Province>();
        }
        public async Task<List<ProvinceDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<ProvinceDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<ProvinceDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<ProvinceDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Saler
{
    public class SalerTypeRepo : ISalerTypeRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        private readonly DbSet<SalerType> _entities;

        public SalerTypeRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<SalerType>();
        }
        public async Task<List<SalerTypeDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<SalerTypeDto>>(await _entities.AsNoTracking().ToListAsync(cancellationToken));



        public async Task<SalerTypeDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SalerTypeDto>(await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

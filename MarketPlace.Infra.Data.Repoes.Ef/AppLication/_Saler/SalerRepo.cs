using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Saler
{
    public class SalerRepo : ISalerRepo
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DbSet<Saler> _entities;
        public SalerRepo(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<Saler>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(SalerInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Saler>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<SalerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<SalerOutputDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<SalerOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SalerOutputDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(SalerInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Saler>(input);
            entity.Id = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }



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
    => _mapper.Map<List<SalerTypeDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<SalerTypeDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SalerTypeDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

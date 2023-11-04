using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateAsync(SalerInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Saler>(InputDto);
            await _dbContext.Set<Saler>().AddAsync(entity, cancellationToken);
           
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Saler>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Saler>().Remove(entity);

        }


        public async Task<List<SalerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<SalerOutputDto>>(await _dbContext.Set<Saler>().AsNoTracking().ToListAsync(cancellationToken));



        public async Task<SalerOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SalerOutputDto>(await _dbContext.Set<Saler>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(SalerInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Saler>(input);
            entity.Id = id;
            _dbContext.Set<Saler>().Update(entity);
           
        }
        public int AllSalersCount() => _dbContext.Set<Saler>().Count();
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
    => _mapper.Map<List<SalerTypeDto>>(await _entities.AsNoTracking().ToListAsync(cancellationToken));



        public async Task<SalerTypeDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SalerTypeDto>(await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

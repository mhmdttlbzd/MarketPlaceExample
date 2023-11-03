using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication
{
    public class BaseEntityCrudRepository<TEntity, TInput, TOutput> :
        IBaseCrudRepository<TEntity, TInput, TOutput> where TEntity : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        //private readonly DbSet<TEntity> _entities;
        public BaseEntityCrudRepository(DbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(TInput InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(InputDto);
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(Id, cancellationToken);
            _dbContext.Set<TEntity>().Remove(entity);
            
        }


        public async Task<List<TOutput>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<TOutput>>(await _dbContext.Set<TEntity>().ToListAsync(cancellationToken));



        public async Task<TOutput> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<TOutput>(await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync( TInput input, int id , CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(input);
            entity.Id = id;
            _dbContext.Set<TEntity>().Update(entity);
        }
    }
}
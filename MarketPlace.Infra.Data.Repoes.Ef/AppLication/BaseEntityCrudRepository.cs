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
        private readonly DbSet<TEntity> _entities;
        public BaseEntityCrudRepository(DbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(TInput InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<TOutput>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<TOutput>>(await _entities.ToListAsync(cancellationToken));



        public async Task<TOutput> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<TOutput>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync( TInput input, int id , CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<TEntity>(input);
            entity.Id = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
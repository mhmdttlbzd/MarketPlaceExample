using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Order
{
    public class OrderLineRepo : IOrderLineRepo
    {

        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DbSet<OrderLine> _entities;
        public OrderLineRepo(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<OrderLine>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrderLineInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderLine>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<OrderLineOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<OrderLineOutputDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<OrderLineOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<OrderLineOutputDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(OrderLineInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderLine>(input);
            entity.Id = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

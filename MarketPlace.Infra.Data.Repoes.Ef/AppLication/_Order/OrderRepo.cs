using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Order
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DbSet<Order> _entities;
        public OrderRepo(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<Order>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrderInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<OrderOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<OrderOutputDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<OrderOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<OrderOutputDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(OrderInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(input);
            entity.Id = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

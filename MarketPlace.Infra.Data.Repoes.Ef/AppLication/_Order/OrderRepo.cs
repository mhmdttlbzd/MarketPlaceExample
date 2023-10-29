using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Order;
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
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Order> _entities;
        public OrderRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Order>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrderInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(InputDto);
            await _dbContext.Set<Order>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Order>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Order>().Remove(entity);

        }


        public async Task<List<OrderOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<OrderOutputDto>>(await _dbContext.Set<Order>().ToListAsync(cancellationToken));



        public async Task<OrderOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<OrderOutputDto>(await _dbContext.Set<Order>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(OrderInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Order>(input);
            entity.Id = id;
            _dbContext.Set<Order>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

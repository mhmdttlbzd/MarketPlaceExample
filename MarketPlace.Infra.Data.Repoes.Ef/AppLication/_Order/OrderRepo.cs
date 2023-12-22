using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Enums;
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
			await _dbContext.SaveChangesAsync();
			return entity.Id;
		}

		public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Set<Order>().FindAsync(Id, cancellationToken);
			_dbContext.Set<Order>().Remove(entity);

		}





		public async Task<List<OrderOutputDto>> GetAllAsync(CancellationToken cancellationToken)
			=> _mapper.Map<List<OrderOutputDto>>(await _dbContext.Set<Order>().AsNoTracking().ToListAsync(cancellationToken));



		public async Task<OrderOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
			=> _mapper.Map<OrderOutputDto>(await _dbContext.Set<Order>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


		public async Task UpdateAsync(OrderInputDto input, int id, CancellationToken cancellationToken)
		{
			var entity = _mapper.Map<Order>(input);
			entity.Id = id;
			_dbContext.Set<Order>().Update(entity);

		}
        public async Task<int> GetSaledProductCount(CancellationToken cancellationToken)
        {
            int res = 0;
            var date = DateTime.Now - TimeSpan.FromDays(7);
            var QuantitiesList = await _dbContext.Set<Order>()
                .Where(o => o.Status == OrderStatus.Bought && o.BuyedAt >= date)
                .Select(o => o.OrderLines.Select(l => l.Quantity).ToList()).AsNoTracking().ToListAsync(cancellationToken);
            foreach (var item in QuantitiesList)
            {
                foreach (var i in item)
                {
                    res += i;
                }
            }
            return res;
        }
        public async Task<int?> GetActiveOrderId(int customerId)
        {
            var order = await _dbContext.Set<Order>().Where(o => o.CustomerId == customerId && o.Status == OrderStatus.Active).AsNoTracking().FirstOrDefaultAsync();
			if (order != null)
			{
				return order.Id;
			}
			return null;
        }
        public async Task<OrderDto> GetActiveOrder(int customerId)
		{
            var order = await _dbContext.Set<Order>().Where(o => o.CustomerId == customerId && o.Status == OrderStatus.Active).Select(o => new OrderDto
			{
				Id = o.Id,
				OrderLines = o.OrderLines.Select(l => new OrderLineDto {
					Date = DateTime.Now,
					ProductName = l.BoothProduct.Product.Name,
					Quantity = l.Quantity,
					Price = l.Quantity * l.BoothProduct.BoothProductsPrices.OrderBy(p => p.FromDate).Select(p => p.Price).FirstOrDefault(),
					SellerId = l.BoothProduct.BoothId
				}).ToList()
			}).AsNoTracking().FirstOrDefaultAsync();
			return order;
        }

		public async Task BuyOrder(int orderId)
		{
			var order = await _dbContext.Set<Order>().FirstOrDefaultAsync(o => o.Id == orderId);
			order.Status = OrderStatus.Bought;
			order.BuyedAt = DateTime.Now;
		}

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}

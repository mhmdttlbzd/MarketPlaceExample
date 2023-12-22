using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Order
{
    public class OrderLineRepo : IOrderLineRepo
    {

        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<OrderLine> _entities;
        public OrderLineRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<OrderLine>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(OrderLineInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderLine>(InputDto);
            await _dbContext.Set<OrderLine>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<OrderLine>().FindAsync(Id, cancellationToken);
            _dbContext.Set<OrderLine>().Remove(entity);

        }


        public async Task<List<OrderLineOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<OrderLineOutputDto>>(await _dbContext.Set<OrderLine>().ToListAsync(cancellationToken));



        public async Task<OrderLineOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<OrderLineOutputDto>(await _dbContext.Set<OrderLine>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(OrderLineInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<OrderLine>(input);
            entity.Id = id;
            _dbContext.Set<OrderLine>().Update(entity);
          
        }

        public async Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken)
        {
            var date = DateTime.Now - TimeSpan.FromDays(7);
            var QuantitiesList = await _dbContext.Set<OrderLine>()
                .Where(o => o.Order.Status == OrderStatus.Bought && o.Order.BuyedAt >= date)
                .Select(o => new SaleOrderLineDto
                {
                    CustomerName = o.Order.Customer.UserName,
                    dateTime = o.Order.BuyedAt,
                    ProductName = o.BoothProduct.Product.Name,
                    Quantity = o.Quantity,
                    BoothName = o.BoothProduct.Booth.Name
                }).AsNoTracking().ToListAsync(cancellationToken);
            return QuantitiesList;
        }
        public async Task<List<SaleOrderLineDto>> GetSaledProducts(int sellerId, CancellationToken cancellationToken)
        {
            var date = DateTime.Now - TimeSpan.FromDays(7);
            var QuantitiesList = await _dbContext.Set<OrderLine>()
                .Where(o => o.Order.Status == OrderStatus.Bought && o.Order.BuyedAt >= date && o.BoothProduct.BoothId == sellerId)
                .Select(o => new SaleOrderLineDto
                {
                    CustomerName = o.Order.Customer.UserName,
                    dateTime = o.Order.BuyedAt,
                    ProductName = o.BoothProduct.Product.Name,
                    Quantity = o.Quantity,
                    BoothName = o.BoothProduct.Booth.Name
                }).AsNoTracking().ToListAsync(cancellationToken);
            return QuantitiesList;
        }

        public async Task<List<OrderLineDto>> GetBuyHistory(int customerId,CancellationToken cancellationToken)
        {
            var res = await _dbContext.Set<OrderLine>().Where(o => o.Order.Status == OrderStatus.Bought && o.Order.CustomerId == customerId)
                .Select(o => new OrderLineDto
                {
                    Date = o.Order.BuyedAt,
                    ProductName = o.BoothProduct.Product.Name,
                    Quantity = o.Quantity
                }).AsNoTracking().ToListAsync(cancellationToken);
            return res;
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}

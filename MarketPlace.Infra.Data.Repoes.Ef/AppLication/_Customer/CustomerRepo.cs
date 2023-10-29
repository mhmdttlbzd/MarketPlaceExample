using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Customer
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Customer> _entities;
        public CustomerRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Customer>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CustomerInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(InputDto);
            await _dbContext.Set<Customer>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Customer>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Customer>().Remove(entity);

        }


        public async Task<List<CustomerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<CustomerOutputDto>>(await _dbContext.Set<Customer>().ToListAsync(cancellationToken));



        public async Task<CustomerOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<CustomerOutputDto>(await _dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(CustomerInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Customer>(input);
            entity.Id = id;
            _dbContext.Set<Customer>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Product
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        private readonly DbSet<Category> _entities;

        public CategoryRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<Category>();
        }
        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<CategoryDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<CategoryDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<CategoryDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

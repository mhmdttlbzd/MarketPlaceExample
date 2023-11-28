using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Product
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Category> _entities;

        public CategoryRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Category>();
        }
        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<CategoryDto>>(await _dbContext.Set<Category>().ToListAsync(cancellationToken));

        public List<CategoryDto> GetAll()
            => _mapper.Map<List<CategoryDto>>( _dbContext.Set<Category>().ToList());

        public async Task<CategoryDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<CategoryDto>(await _dbContext.Set<Category>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));
    }
}

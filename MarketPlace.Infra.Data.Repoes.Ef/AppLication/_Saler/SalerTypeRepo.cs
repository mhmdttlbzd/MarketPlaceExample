using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Saler
{
    public class SalerTypeRepo : ISalerTypeRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        private readonly DbSet<SellerType> _entities;

        public SalerTypeRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<SellerType>();
        }
        public async Task<List<SellerTypeDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<SellerTypeDto>>(await _entities.AsNoTracking().ToListAsync(cancellationToken));

        public List<SellerTypeDto> GetAll()
=> _mapper.Map<List<SellerTypeDto>>( _entities.AsNoTracking().ToList());



        public async Task<SellerTypeDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<SellerTypeDto>(await _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


    }
}

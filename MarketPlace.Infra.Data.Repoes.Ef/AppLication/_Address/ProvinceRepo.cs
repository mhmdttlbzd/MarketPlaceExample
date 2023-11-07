using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Address
{
    public class ProvinceRepo : IProvinceRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Province> _entities;

        public ProvinceRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Province>();
        }
        public List<ProvinceDto> GetAll() => _mapper.Map<List<ProvinceDto>>(_dbContext.Set<Province>().AsNoTracking().ToList());

        public async Task<List<ProvinceDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<ProvinceDto>>(await _dbContext.Set<Province>().ToListAsync(cancellationToken));



        public async Task<ProvinceDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<ProvinceDto>(await _dbContext.Set<Province>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

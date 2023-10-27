using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Address
{
    public class CityRepo : ICityRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        private readonly DbSet<City> _entities;

        public CityRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<City>();
        }
        public async Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<CityDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<CityDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<CityDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

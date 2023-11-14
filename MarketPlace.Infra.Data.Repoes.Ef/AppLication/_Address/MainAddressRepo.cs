using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Address
{
    public class MainAddressRepo : IMainAddressRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        public MainAddressRepo(MarketPlaceDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(MainAddressInputDto input, CancellationToken cancellationToken)
        {
            var res =await _dbContext.Set<MainAddress>().AddAsync(_mapper.Map<MainAddress>(input), cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return res.Entity.Id;
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<MainAddressOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<MainAddressOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var address=await _dbContext.Set<MainAddress>().Where(a =>a.Id== id)
                .Select(a => new MainAddressOutputDto
                {
                    CityId=a.CityId,
                    Description = a.Address,
                    ProvinceId = a.City.ProvinceId,
                    PostalCode = a.PostalCode
                })
                .AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return address;
        }

        public async Task UpdateAsync(MainAddressInputDto input, int id, CancellationToken cancellationToken)
        {
            var address= await _dbContext.Set<MainAddress>().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
                address.CityId = input.CityId;
                address.Address = input.Address;
                address.PostalCode = input.PostalCode;
        }
    }
}

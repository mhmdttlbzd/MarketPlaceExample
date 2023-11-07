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
    public class MainAddressRepo : BaseEntityCrudRepository<MainAddress,
        MainAddressInputDto, MainAddressOutputDto>,IMainAddressRepo
    {
        public MainAddressRepo(MarketPlaceDbContext dbContext,IMapper mapper) : base(dbContext,mapper)
        {
            
        }
        public async override Task UpdateAsync(MainAddressInputDto input, int id, CancellationToken cancellationToken)
        {
            var address= await _dbContext.Set<MainAddress>().FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
                address.CityId = input.CityId;
                address.Address = input.Address;
                address.PostalCode = input.PostalCode;
        }
    }
}

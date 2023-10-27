using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;
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
    }
}

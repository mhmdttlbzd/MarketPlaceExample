using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Customer;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Customer
{
    public class CustomerRepo : BaseEntityCrudRepository<Customer,
    CustomerInputDto, CustomerOutputDto>, ICustomerRepo
    {
        public CustomerRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}

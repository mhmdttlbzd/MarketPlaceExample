using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Infra.Db.SqlServer.Ef;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class BoothProductsPriceRepo : IBoothProductsPriceRepo
    {
        public BoothProductsPriceRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {

        }

        public Task<int> CreateAsync(BoothProductsPriceInputDto input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoothProductsPriceOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BoothProductsPriceOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BoothProductsPriceInputDto input, int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

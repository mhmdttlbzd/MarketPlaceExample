using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Booth
{
    public class BoothService : IBoothService
    {
        private readonly IBoothRepo _boothRepo;

        public BoothService(IBoothRepo boothRepo)
        {
            _boothRepo = boothRepo;
        }

        public async Task<int> CreateAsync(BoothInputDto input, CancellationToken cancellationToken)
        {
            return await _boothRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _boothRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<BoothOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _boothRepo.GetAllAsync(cancellationToken);
        }

        public async Task<BoothOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boothRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task<GeneralBoothDto> GetGeneralBoothById(int id, CancellationToken cancellationToken)
            => await _boothRepo.GetGeneralBoothById(id, cancellationToken);

        public async Task UpdateAsync(BoothInputDto input, int id, CancellationToken cancellationToken)
        {
            await _boothRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}

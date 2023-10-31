using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Saler
{
    public class SalerService : ISalerService
    {
        private readonly ISalerRepo _salerRepo;

        public SalerService(ISalerRepo salerRepo)
        {
            _salerRepo = salerRepo;
        }

        public async Task<int> CreateAsync(SalerInputDto input, CancellationToken cancellationToken)
        {
            return await _salerRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _salerRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<SalerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _salerRepo.GetAllAsync(cancellationToken);
        }

        public async Task<SalerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _salerRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(SalerInputDto input, int id, CancellationToken cancellationToken)
        {
            await _salerRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}

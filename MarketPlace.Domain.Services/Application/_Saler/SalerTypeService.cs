using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Saler
{
    public class SalerTypeService : ISalerTypeService
    {
        private readonly ISalerTypeRepo _salerTypeRepo;

        public SalerTypeService(ISalerTypeRepo salerTypeRepo)
        {
            _salerTypeRepo = salerTypeRepo;
        }

        public async Task<List<SalerTypeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _salerTypeRepo.GetAllAsync(cancellationToken);
        }

        public async Task<SalerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _salerTypeRepo.GetByIdAsync(id, cancellationToken);
        }
    }
}

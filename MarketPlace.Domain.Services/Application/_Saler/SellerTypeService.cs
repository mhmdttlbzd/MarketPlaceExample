using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services._Saler;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Saler
{
    public class SellerTypeService : ISalerTypeService
    {
        private readonly ISalerTypeRepo _salerTypeRepo;

        public SellerTypeService(ISalerTypeRepo salerTypeRepo)
        {
            _salerTypeRepo = salerTypeRepo;
        }

        public async Task<List<SellerTypeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _salerTypeRepo.GetAllAsync(cancellationToken);
        }

        public async Task<SellerTypeDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _salerTypeRepo.GetByIdAsync(id, cancellationToken);
        }
        public int GetCount() => _salerTypeRepo.GetCount();
    }
}

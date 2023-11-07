using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Address
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepo _provinceRepo;

        public ProvinceService(IProvinceRepo provinceRepo)
        {
            _provinceRepo = provinceRepo;
        }
        public List<ProvinceDto> GetAll() => _provinceRepo.GetAll();

        public async Task<List<ProvinceDto>> GetAllAsync(CancellationToken cancellationToken)
        {
           return await _provinceRepo.GetAllAsync(cancellationToken);
        }

        public async Task<ProvinceDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _provinceRepo.GetByIdAsync(id, cancellationToken);
        }
    }
}

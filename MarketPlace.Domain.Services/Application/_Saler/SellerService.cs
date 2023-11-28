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
    public class SellerService : ISalerService
    {
        private readonly ISalerRepo _sellerRepo;

        public SellerService(ISalerRepo salerRepo)
        {
            _sellerRepo = salerRepo;
        }

        public async Task<int> CreateAsync(SellerInputDto input, CancellationToken cancellationToken)
            => await _sellerRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _sellerRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<SellerOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _sellerRepo.GetAllAsync(cancellationToken);

        public async Task<SellerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _sellerRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(SellerInputDto input, int id, CancellationToken cancellationToken)
            =>await _sellerRepo.UpdateAsync(input, id, cancellationToken);

        public int AllSalersCount() => _sellerRepo.AllSellersCount();
        public async Task<List<GeneralSellerDto>> GetGeneralSellers(CancellationToken cancellationToken)
            => await _sellerRepo.GetGeneralSellers(cancellationToken);

        public byte GetWagePercent(int sellerId) => _sellerRepo.GetWagePercent(sellerId);
        public async Task<GeneralSellerDto> GetGeneralSeller(int id) => await _sellerRepo.GetGeneralSeller(id);
    }
}

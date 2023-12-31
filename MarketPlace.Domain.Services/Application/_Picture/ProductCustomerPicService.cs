﻿using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Picture
{
    public class ProductCustomerPicService : IProductCustomerPicService
    {
        private readonly IProductCustomerPicRepo _productCustomerPicRepo;

        public ProductCustomerPicService(IProductCustomerPicRepo productCustomerPicRepo)
        {
            _productCustomerPicRepo = productCustomerPicRepo;
        }
        public int GetCount() => _productCustomerPicRepo.GetCount();
        public async Task<int> CreateAsync(ProductCustomerPicInputDto input, CancellationToken cancellationToken)
        {
            return await _productCustomerPicRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _productCustomerPicRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<ProductCustomerPicOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _productCustomerPicRepo.GetAllAsync(cancellationToken);

        public async Task<ProductCustomerPicOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _productCustomerPicRepo.GetByIdAsync(id, cancellationToken);


        public async Task UpdateAsync(ProductCustomerPicInputDto input, int id, CancellationToken cancellationToken)
            =>await _productCustomerPicRepo.UpdateAsync(input, id, cancellationToken);

		public int GetRequestsCount() => _productCustomerPicRepo.GetRequestsCount();

        public async Task<List<CustomerPicRequestDto>> GetRequests(CancellationToken cancellationToken)
=> await _productCustomerPicRepo.GetRequests(cancellationToken);

        public async Task ConfirmAsync(int id, CancellationToken cancellationToken) => await _productCustomerPicRepo.ConfirmAsync(id, cancellationToken);
        public async Task FaleAsync(int id, CancellationToken cancellationToken) => await _productCustomerPicRepo.FaleAsync(id, cancellationToken);


    }

}

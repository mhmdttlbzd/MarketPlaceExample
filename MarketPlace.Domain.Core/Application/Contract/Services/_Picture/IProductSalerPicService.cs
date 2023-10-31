﻿using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Picture
{
    public interface IProductSalerPicService
    {
        Task<int> CreateAsync(ProductSalerPicInputDto input, CancellationToken cancellationToken);
        Task<List<ProductSalerPicOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductSalerPicOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(ProductSalerPicInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
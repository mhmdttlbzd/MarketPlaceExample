﻿using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IProductSalerPicRepo : IBaseCrudRepository<ProductSalerPic, ProductSalerPicInputDto, ProductSalerPicOutputDto>
    {
		int GetRequestsCount();
		Task FaleAsync(int id, CancellationToken cancellationToken);
		Task ConfirmAsync(int id, CancellationToken cancellationToken);
		Task<List<SalerPicRequestDto>> GetRequests(CancellationToken cancellationToken);
	}
}

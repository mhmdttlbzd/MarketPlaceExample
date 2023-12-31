﻿using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Picture
{
    public interface IAuctionPictureService
    {
        Task<int> CreateAsync(AuctionPictureInputDto input, CancellationToken cancellationToken);
        Task<List<AuctionPictureOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AuctionPictureOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AuctionPictureInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int GetRequestsCount();
        int GetCount();
        Task<List<AuctionPicRequestDto>> GetRequests(CancellationToken cancellationToken);
		Task FaleAsync(int id, CancellationToken cancellationToken);
		Task ConfirmAsync(int id, CancellationToken cancellationToken);
	}
}

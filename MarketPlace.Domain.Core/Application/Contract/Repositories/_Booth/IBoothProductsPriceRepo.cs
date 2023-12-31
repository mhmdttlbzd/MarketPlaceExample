﻿using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Booth
{
    public interface IBoothProductsPriceRepo : IBaseCrudRepository<BoothProductsPrice, BoothProductsPriceInputDto, BoothProductsPriceOutputDto>
    {
        Task Teminate(int id);
        int GetLastPriceIdByProductId(int productId);
       List<ProductPriceDto> GetPricesByProductId(int productId);
    }
}

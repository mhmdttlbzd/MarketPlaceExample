﻿using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Booth
{
    public interface IBoothProductsPriceRepo : IBaseCrudRepository<BoothProductsPrice, BoothProductsPriceInputDto, BoothProductsPriceOutputDto>
    {

    }
}

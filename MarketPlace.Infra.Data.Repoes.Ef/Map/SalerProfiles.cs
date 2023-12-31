﻿using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class SalerProfiles: Profile
    {
        public SalerProfiles()
        {
            CreateMap<Seller,SellerOutputDto>();
            CreateMap<SellerInputDto, Seller>();

            CreateMap<SellerType, SellerTypeDto>();
        }
    }
}

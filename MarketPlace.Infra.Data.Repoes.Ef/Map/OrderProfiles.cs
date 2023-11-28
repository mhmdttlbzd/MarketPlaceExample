using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class OrderProfiles :Profile
    {
        public OrderProfiles()
        {
            CreateMap<Order, OrderOutputDto>();
            CreateMap<OrderInputDto, Order>();

            CreateMap<OrderLine, OrderLineOutputDto>();
            CreateMap<OrderLineInputDto, OrderLine>();
        }
    }
}

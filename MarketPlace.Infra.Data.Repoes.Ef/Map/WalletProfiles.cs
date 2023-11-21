using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class WalletProfiles : Profile
    {
        public WalletProfiles()
        {
            CreateMap<WalletTransaction, WalletTransactionDto>();
        }
    }
}

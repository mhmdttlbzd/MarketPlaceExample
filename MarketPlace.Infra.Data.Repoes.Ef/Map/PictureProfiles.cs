using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class PictureProfiles : Profile
    {
        public PictureProfiles()
        {
            CreateMap<Picture, PictureDto>();

            CreateMap<ProductCustomerPic, ProductCustomerPicOutputDto>();
            CreateMap<ProductCustomerPic, ProductCustomerPicInputDto>();

            CreateMap<AuctionPicture, AuctionPictureOutputDto>();
            CreateMap<AuctionPicture, AuctionPictureInputDto>();

            CreateMap<ProductSalerPic, ProductSalerPicOutputDto>();
            CreateMap<ProductSalerPic, ProductSalerPicInputDto>();
        }
    }
}

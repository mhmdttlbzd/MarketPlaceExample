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
            CreateMap<ProductCustomerPicInputDto, ProductCustomerPic>();

            CreateMap<AuctionPicture, AuctionPictureOutputDto>();
            CreateMap<AuctionPictureInputDto, AuctionPicture>();

            CreateMap<ProductSalerPic, ProductSalerPicOutputDto>();
            CreateMap<ProductSalerPicInputDto, ProductSalerPic>();
        }
    }
}

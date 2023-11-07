using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class BoothProfiles :Profile
    {
        public BoothProfiles()
        {
            CreateMap<Booth, BoothOutputDto>();
            CreateMap<BoothInputDto, Booth>();

            CreateMap<BoothProduct, BoothProductOutputDto>();
            CreateMap<BoothProductInputDto, BoothProduct>();

            CreateMap<BoothProductsPrice, BoothProductsPriceOutputDto>();
            CreateMap<BoothProductsPriceInputDto, BoothProductsPrice>();

            CreateMap<Comment, CommentOutputDto>();
            CreateMap<CommentInputDto, Comment>();
        }
    }
}

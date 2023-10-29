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
            CreateMap<Booth, BoothInputDto>();

            CreateMap<Booth, BoothProductOutputDto>();
            CreateMap<Booth, BoothProductInputDto>();

            CreateMap<Booth, BoothProductsPriceOutputDto>();
            CreateMap<Booth, BoothProductsPriceInputDto>();

            CreateMap<Comment, CommentOutputDto>();
            CreateMap<Comment, CommentInputDto>();
        }
    }
}

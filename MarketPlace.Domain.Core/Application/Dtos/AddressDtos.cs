using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{

    #region MainAddress

    public record MainAddressInputDto(
        int CityId, string Address, int PostalCode
        );
    public record MainAddressOutputDto
    {
        public int CityId { get; set; }
        public int PostalCode { get; set; }
        public string Description { get; set; }
        public int ProvinceId { get; set; }
    }

    #endregion


    #region City
    public record CityDto(
        int Id,string Name,int ProvinceId,ICollection<MainAddressOutputDto> Addresses,ProvinceDto Province
        );
    #endregion


    #region Province
    public record ProvinceDto(
        int Id,string Name, ICollection<CityDto> Cities
        );
    #endregion
}

using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{

    #region MainAddress
    public record MainAddressOutputDto(
        int Id, int CityId, string Address, int PostalCode, ICollection<Booth> Booths,
         CityOutputDto City, ICollection<CustomerOutputDto> Customers
        );
    public record MainAddressInputDto(
        int CityId, string Address, int PostalCode
        );
    #endregion


    #region City
    public record CityOutputDto(
        int Id,string Name,int ProvinceId,ICollection<MainAddressOutputDto> Addresses,ProvinceOutputDto Province
        );
    #endregion


    #region Province
    public record ProvinceOutputDto(
        int Id,string Name, ICollection<CityOutputDto> Cities
        );
    #endregion
}

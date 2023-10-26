using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Saler
    public record SalerOutputDto(
        int Id, int SalerTypeId, BoothOutputDto? Booth, SalerTypeDto SalerTipe
        );
    public record SalerInputDto(int SalerTypeId=1);
    #endregion

    #region SalerType
    public record SalerTypeDto(int Id, string Title, byte TaskPercent, ICollection<SalerOutputDto> Salers);
    #endregion
}

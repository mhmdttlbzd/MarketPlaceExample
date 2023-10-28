using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    public record AdminInputDto(string PersonalCode);
    public record AdminOutputDto(int Id,string PersonalCode);
}

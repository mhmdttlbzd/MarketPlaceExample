using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface IBoothProductAppService
    {
        Task Create(List<string> paths, BoothProductModel model, CancellationToken cancellationToken, string username);
    }
}

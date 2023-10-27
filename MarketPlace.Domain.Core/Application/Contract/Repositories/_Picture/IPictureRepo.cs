using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IPictureRepo 
    {
        Task<int> CreateAsync(string path,CancellationToken cancellationToken,string? alt = null);
        Task<PictureDto> GetByIdAsync(int id,CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

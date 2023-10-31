using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Picture
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepo _pictureRepo;

        public PictureService(IPictureRepo pictureRepo)
        {
            _pictureRepo = pictureRepo;
        }

        public async Task<int> CreateAsync(string path, CancellationToken cancellationToken, string? alt = null)
        {
            return await _pictureRepo.CreateAsync(path, cancellationToken, alt);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _pictureRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<PictureDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _pictureRepo.GetByIdAsync(id, cancellationToken);
        }
    }

}

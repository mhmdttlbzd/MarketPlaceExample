using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Picture
{
    public class PictureRepo : IPictureRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Picture> _entities;

        public PictureRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Picture>();
        }

        public async Task<int> CreateAsync(string path, CancellationToken cancellationToken, string? alt = null)
        {
            var entity = new Picture { Path = path, Alt = alt };
            await _dbContext.Set<Picture>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Picture>().FindAsync(id, cancellationToken);
            _dbContext.Set<Picture>().Remove(entity);
        }

        public async Task<PictureDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<PictureDto>(await _dbContext.Set<Picture>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

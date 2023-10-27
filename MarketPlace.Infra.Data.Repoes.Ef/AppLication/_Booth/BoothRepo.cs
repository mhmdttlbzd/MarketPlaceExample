using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Booth
{
    public class BoothRepo : IBoothRepo
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DbSet<Booth> _entities;
        public BoothRepo(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<Booth>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(BoothInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.SalerId;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<BoothOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<BoothOutputDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<BoothOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<BoothOutputDto>(await _entities.FirstOrDefaultAsync(x => x.SalerId == Id, cancellationToken));


        public async Task UpdateAsync(BoothInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(input);
            entity.SalerId = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

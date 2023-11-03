using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Auction;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Infra.Db.SqlServer.Ef;
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
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<Booth> _entities;
        public BoothRepo(MarketPlaceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            //_entities = _dbContext.Set<Booth>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(BoothInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(InputDto);
            await _dbContext.Set<Booth>().AddAsync(entity, cancellationToken);
            
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Booth>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Booth>().Remove(entity);

        }


        public async Task<List<BoothOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<BoothOutputDto>>(await _dbContext.Set<Booth>().ToListAsync(cancellationToken));



        public async Task<BoothOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<BoothOutputDto>(await _dbContext.Set<Booth>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(BoothInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Booth>(input);
            entity.Id = id;
            _dbContext.Set<Booth>().Update(entity);
           
        }
    }
}

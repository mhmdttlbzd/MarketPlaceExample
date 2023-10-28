using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Admin;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Admin
{
    public class AdminRepo : IAdminRepo
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;
        private readonly DbSet<Admin> _entities;
        public AdminRepo(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<Admin>();
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(AdminInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Admin>(InputDto);
            await _entities.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(Id, cancellationToken);
            _entities.Remove(entity);

        }


        public async Task<List<AdminOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => _mapper.Map<List<AdminOutputDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<AdminOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<AdminOutputDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));


        public async Task UpdateAsync(AdminInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Admin>(input);
            entity.Id = id;
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}

using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._CustomAttribute
{
    public class AttributeTemplateRepo : IAttributeTemplateRepo
    {
        private readonly IMapper _mapper;
        private readonly MarketPlaceDbContext _dbContext;
        //private readonly DbSet<CustomAttributeTemplate> _entities;

        public AttributeTemplateRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            //_entities = _dbContext.Set<CustomAttributeTemplate>();
        }
        public async Task<List<AttributeTemplateOutputDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<AttributeTemplateOutputDto>>(await _dbContext.Set<CustomAttributeTemplate>().ToListAsync(cancellationToken));



        public async Task<AttributeTemplateOutputDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<AttributeTemplateOutputDto>(await _dbContext.Set<CustomAttributeTemplate>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

        public async Task UpdateAsync(AttributeTemplateInputDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CustomAttributeTemplate>(input);
            entity.Id = id;
            _dbContext.Set<CustomAttributeTemplate>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> CreateAsync(AttributeTemplateInputDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CustomAttributeTemplate>(InputDto);
            await _dbContext.Set<CustomAttributeTemplate>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<Booth>().FindAsync(Id, cancellationToken);
            _dbContext.Set<Booth>().Remove(entity);

        }
    }
}

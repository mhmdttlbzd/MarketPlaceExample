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
        public async Task<List<AttributeTemplateDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<AttributeTemplateDto>>(await _dbContext.Set<CustomAttributeTemplate>().ToListAsync(cancellationToken));



        public async Task<AttributeTemplateDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<AttributeTemplateDto>(await _dbContext.Set<CustomAttributeTemplate>().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

        public async Task UpdateAsync(AttributeTemplateDto input, int id, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CustomAttributeTemplate>(input);
            entity.Id = id;
            _dbContext.Set<CustomAttributeTemplate>().Update(entity);
           
        }
        public async Task<int> CreateAsync(AttributeTemplateDto InputDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<CustomAttributeTemplate>(InputDto);
            await _dbContext.Set<CustomAttributeTemplate>().AddAsync(entity, cancellationToken);
            
            return entity.Id;
        }

        public async Task DeleteAsync(int Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Set<CustomAttributeTemplate>().FirstOrDefaultAsync(c => c.Id ==Id, cancellationToken);
            _dbContext.Set<CustomAttributeTemplate>().Remove(entity);

        }

        public async Task<List<AttributeTemplateDto>> GetByCategoryId(int? id,CancellationToken cancellationToken)
        {
             return await _dbContext.Set<CategoryCustomAttribute>().Where(c => c.CategoryId == id)
                .Select(c => new AttributeTemplateDto
                {
                    Id = c.CustomAttributeTemplateId,
                    Title = c.CustomAttributeTemplate.Title
                }).ToListAsync(cancellationToken);
        }
    }
}

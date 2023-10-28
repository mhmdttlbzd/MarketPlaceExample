using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
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
        private readonly DbSet<CustomAttributeTemplate> _entities;

        public AttributeTemplateRepo(IMapper mapper, MarketPlaceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _entities = _dbContext.Set<CustomAttributeTemplate>();
        }
        public async Task<List<AttributeTemplateDto>> GetAllAsync(CancellationToken cancellationToken)
    => _mapper.Map<List<AttributeTemplateDto>>(await _entities.ToListAsync(cancellationToken));



        public async Task<AttributeTemplateDto> GetByIdAsync(int Id, CancellationToken cancellationToken)
            => _mapper.Map<AttributeTemplateDto>(await _entities.FirstOrDefaultAsync(x => x.Id == Id, cancellationToken));

    }
}

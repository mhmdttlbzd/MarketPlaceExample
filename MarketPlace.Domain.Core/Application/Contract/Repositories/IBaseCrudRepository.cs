using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories
{
    public interface IBaseCrudRepository<TEntity,TInput,TOutput> where TEntity : class
    {
        Task<int> CreateAsync(TInput input,CancellationToken cancellationToken);
        Task<List<TOutput>> GetAllAsync(CancellationToken cancellationToken);
        Task<TOutput> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(TInput input,int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}

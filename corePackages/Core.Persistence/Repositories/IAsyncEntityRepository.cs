using Core.Persistence.EntityBaseModel;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public interface IAsyncEntityRepository<TEntity, TId> where TEntity : Entity<TId>
{
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);

    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    Task<TEntity?> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}

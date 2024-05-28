using Core.Persistence.EntityBaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories;

public class EfRepositoryBase<TContext, TEntity, TId> : IEntityRepository<TEntity, TId>, IAsyncEntityRepository<TEntity, TId>, IQuery<TEntity> where TEntity : Entity<TId> where TContext : DbContext
{
    protected TContext Context { get; set; }

    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }

    public virtual void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
    }

    public virtual void Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
    }

    public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();

        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (include != null)
            queryable = include(queryable);

        return queryable.ToList();
    }

    public virtual TEntity? GetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(predicate);

        if (include != null)
            queryable = include(queryable);

        return queryable.FirstOrDefault();
    }

    public virtual TEntity? GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (include != null)
            queryable = include(queryable);

        return queryable.SingleOrDefault(x => x.Id.Equals(id));
    }

    public virtual void Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
    }

    public IQueryable<TEntity> Query() => Context.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();

        if (predicate != null)
            queryable = queryable.Where(predicate);
        if (include != null)
            queryable = include(queryable);

        return await queryable.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(x => x.Id.Equals(id));
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync();
    }

    public async Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(predicate);
        if (include != null) queryable = include(queryable);
        return await queryable.FirstOrDefaultAsync();
    }
}

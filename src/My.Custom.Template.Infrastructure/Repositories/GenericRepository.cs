﻿using Microsoft.EntityFrameworkCore;
using My.Custom.Template.Common;
using My.Custom.Template.Common.DDD;
using My.Custom.Template.Common.Extensions;
using My.Custom.Template.Common.Response;
using System.Linq.Expressions;

namespace My.Custom.Template.Infrastructure.Repositories;

public class GenericRepository<T, TId> : IGenericRepository<T, TId> where T : AggregateRoot<TId> where TId : ValueObject
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        return await _dbSet
            .FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate == null) return await _context.Set<T>().ToListAsync();

        return await _dbSet.Where(predicate).AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Dictionary<TId, T>> GetAllAsyncDict(CancellationToken cancellationToken, Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate == null) return await _context.Set<T>().ToDictionaryAsync(x => x.Id, cancellationToken);

        return await _dbSet.Where(predicate).AsNoTracking().ToDictionaryAsync(x => x.Id, cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        entity.Activate();
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<PaginatedResult<T>> GetAllPaginatedAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
    {
        IQueryable<T> query = _dbSet.AsNoTracking();

        return await query
            .ToPaginatedResultAsync(pageNumber, pageSize, cancellationToken);
    }
}
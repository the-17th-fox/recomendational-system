using System.Linq.Expressions;
using BillDivider.Core.Entities;
using BillDivider.Core.Interfaces.Repository;
using BillDivider.Core.Models;
using BillDivider.Infrastructure.Context;
using BillDivider.Infrastructure.Extensions.EFCoreExtension;
using Microsoft.EntityFrameworkCore;

namespace BillDivider.Infrastructure.Repositories.EFRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly BillDividerContext _context;
    private readonly DbSet<T> _table;

    public GenericRepository(BillDividerContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    /// <inheritdoc/>
    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public void Delete(T entity)
    {
        _table.Remove(entity);
    }

    /// <inheritdoc/>
    public async Task<T?> GetAsync(
        Expression<Func<T, bool>> searchPredicate, 
        bool trackChanges = true,
        CancellationToken cancellationToken = default, 
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = ComposeQuery(searchPredicate, trackChanges, includeProperties);
        
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<T[]> GetAllAsync(
        PaginationSettings paginationSettings,
        Expression<Func<T, bool>>? searchPredicate,
        bool trackChanges = true,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = ComposeQuery(searchPredicate, trackChanges, includeProperties);
        
        return query
            .OrderBy(p => p.Id)
            .ApplyPagination(paginationSettings)
            .ToArrayAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public void Update(T entity)
    {
        _table.Update(entity);
    }

    /// <inheritdoc/>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<T> ComposeQuery(
        Expression<Func<T, bool>>? searchPredicate,
        bool trackChanges,
        params Expression<Func<T, object>>[] includeProperties)
    {
        var query = trackChanges 
            ? _table.AsQueryable().AsNoTracking() 
            : _table.AsQueryable();
        
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        
        return searchPredicate is not null ? query.Where(searchPredicate) : query;
    }
}

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

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _table.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        T? deletingEntity = await _table.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (deletingEntity == null)
        {
            throw new KeyNotFoundException();
        }

        _table.Remove(deletingEntity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await _table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        return entity;
    }

    public async Task<List<T>> GetAllAsync(PaginationSettings paginationSettings, CancellationToken cancellationToken)
    {
        return await _table
            .OrderBy(p => p.Id)
            .ApplyPagination(paginationSettings)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        var updatingEntity = await _table.AsNoTracking().FirstOrDefaultAsync(p => p.Id == entity.Id, cancellationToken);

        if (updatingEntity == null)
        {
            throw new KeyNotFoundException();
        }

        _table.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

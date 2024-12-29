using BillDivider.Core.Entities;
using BillDivider.Core.Models;

namespace BillDivider.Core.Interfaces.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    public Task CreateAsync(T entity, CancellationToken cancellationToken);
    public Task DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task<List<T>> GetAllAsync(PaginationSettings paginationSettings, CancellationToken cancellationToken);
    public Task UpdateAsync(T entity, CancellationToken cancellationToken);
}

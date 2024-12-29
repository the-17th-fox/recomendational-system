using System.Linq.Expressions;
using BillDivider.Core.Entities;
using BillDivider.Core.Models;

namespace BillDivider.Core.Interfaces.Repository;

public interface IGenericRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Marks entity as added in Change tracker
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>Async operation</returns>
    public Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Marks entity as deleted in Change tracker
    /// </summary>
    /// <param name="entity">Entity to delete</param>
    public void Delete(T entity);
    
    /// <summary>
    /// Gets single entity or null by specified predicate
    /// </summary>
    /// <param name="searchPredicate">Searching predicate</param>
    /// <param name="trackChanges">Should the entity be tracked by EF</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <param name="includeProperties">Collection of entity properties to include in request</param>
    /// <returns>Single entity or null</returns>
    public Task<T?> GetAsync(
        Expression<Func<T, bool>> searchPredicate, 
        bool trackChanges = true,
        CancellationToken cancellationToken = default, 
        params Expression<Func<T, object>>[] includeProperties);
    
    /// <summary>
    /// Gets a collection of entities by specified predicate and pagination settings
    /// </summary>
    /// <param name="paginationSettings">Page size and page number</param>
    /// <param name="searchPredicate">Searching predicate</param>
    /// <param name="trackChanges">Should the entity be tracked by EF</param>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <param name="includeProperties">Collection of entity properties to include in request</param>
    /// <returns>A collection of entities</returns>
    public Task<T[]> GetAllAsync(
        PaginationSettings paginationSettings,
        Expression<Func<T, bool>>? searchPredicate,
        bool trackChanges = true,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includeProperties);
    
    /// <summary>
    /// Marks entity as modified in Change tracker
    /// </summary>
    /// <param name="entity">Entity to update</param>
    public void Update(T entity);
    
    /// <summary>
    /// Saves pending changes to the DB
    /// </summary>
    /// <param name="cancellationToken">Task cancellation token</param>
    /// <returns>Async opearation</returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}

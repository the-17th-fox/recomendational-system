using BillDivider.Core.Models;

namespace BillDivider.Infrastructure.Extensions.EFCoreExtension
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginationSettings paginationSettings) 
        {
            return query.Skip((paginationSettings.PageNumber-1)*paginationSettings.PageSize).Take(paginationSettings.PageSize);
        }
       

    }
}

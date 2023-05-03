using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Infrastructure.FilteringSystem;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Extensions;

public static class QueryableExtensions
{
    public static async Task<TEntity> FirstAsyncOrThrow<TEntity>(this IQueryable<TEntity> query, Expression<Func<TEntity, bool>> predicate)
    {
        return await query.FirstOrDefaultAsync(predicate) ?? throw new EntityNotFoundException(typeof(TEntity).Name);
    }
    
    public static async Task<TEntity> FirstAsyncOrThrow<TEntity>(this IQueryable<TEntity> query, string propertyName, string value)
    {
        query = query.Where($"{propertyName} == @0", value);
        return await query.FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(TEntity).Name);
    }

    public static IQueryable<TEntity> ApplyPagination<TEntity>(this IQueryable<TEntity> query, Pagination pagination)
    {
        return query
            .Skip(pagination.Offset)
            .Take(pagination.Limit);
    }
    
    public static IQueryable<TEntity> ApplySorting<TEntity>(this IQueryable<TEntity> query, Sorting primarySorting,
        IEnumerable<Sorting>? secondarySortings = null)
    {
        string BuildOrderBy(Sorting sortingInfo)
        {
            return $"{sortingInfo.PropertyName} {sortingInfo.SortingSide}";
        }
        
        IOrderedQueryable<TEntity> orderedQueryable = query.OrderBy(BuildOrderBy(primarySorting));

        if (secondarySortings is null)
        {
            return orderedQueryable;
        }
        
        foreach (var secondarySorting in secondarySortings)
        {
            orderedQueryable =
                orderedQueryable.ThenBy(BuildOrderBy(secondarySorting));
        }

        return orderedQueryable;
    }
}
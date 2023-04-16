using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.ProductService;

public record GetProductsQuery
{
    public Pagination Pagination { get; }
    public ProductSortingCollection SortingCollection { get; }
    public ProductFluentFilters FluentFilters { get; }

    public GetProductsQuery(Pagination pagination, ProductSortingCollection sortingCollection, ProductFluentFilters fluentFilters)
    {
        Pagination = pagination;
        SortingCollection = sortingCollection;
        FluentFilters = fluentFilters;
    }
}
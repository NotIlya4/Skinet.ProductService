using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.ProductService.Views;

public class GetProductsRequest
{
    public Pagination Pagination { get; }
    public ProductSortingCollection Sorting { get; }
    public ProductFluentFilters Filters { get; }
    
    public GetProductsRequest(Pagination? pagination = null, ProductSortingCollection? sorting = null, ProductFluentFilters? filters = null)
    {
        Pagination = pagination ?? new Pagination();
        Sorting = sorting ?? new ProductSortingCollection();
        Filters = filters ?? new ProductFluentFilters();
    }
}
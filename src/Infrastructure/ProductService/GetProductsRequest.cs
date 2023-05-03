using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.SortingSystem.Product;

namespace Infrastructure.ProductService;

public class GetProductsRequest
{
    public Pagination Pagination { get; }
    public ProductSortingCollection SortingCollection { get; }
    public ProductFluentFilters FluentFilters { get; }

    public GetProductsRequest() : this(new Pagination(), new ProductSortingCollection(), new ProductFluentFilters())
    {
        
    }
    
    public GetProductsRequest(Pagination pagination) : this(pagination, new ProductSortingCollection(), new ProductFluentFilters())
    {
        
    }

    public GetProductsRequest(ProductSortingCollection sorting) : this(new Pagination(), sorting, new ProductFluentFilters())
    {
        
    }

    public GetProductsRequest(ProductFluentFilters filters) : this(new Pagination(), new ProductSortingCollection(), filters)
    {
        
    }
    
    public GetProductsRequest(Pagination pagination, ProductSortingCollection sortingCollection, ProductFluentFilters fluentFilters)
    {
        Pagination = pagination;
        SortingCollection = sortingCollection;
        FluentFilters = fluentFilters;
    }
}
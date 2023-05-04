using Domain.Primitives;

namespace Infrastructure.FilteringSystem.Product;

public record ProductFluentFilters
{
    public ProductType? ProductType { get; }
    public Brand? Brand { get; }
    public Name? Searching { get; }
    
    public ProductFluentFilters(ProductType? productType = null, Brand? brand = null, Name? searching = null)
    {
        ProductType = productType;
        Brand = brand;
        Searching = searching;
    }
}
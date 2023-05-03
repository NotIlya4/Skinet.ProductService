using Domain.Primitives;

namespace Infrastructure.FilteringSystem.Product;

public record ProductFluentFilters
{
    public Name? ProductType { get; }
    public Name? Brand { get; }
    public Name? Searching { get; }
    
    public ProductFluentFilters(Name? productType = null, Name? brand = null, Name? searching = null)
    {
        ProductType = productType;
        Brand = brand;
        Searching = searching;
    }
}
using Infrastructure.Misc;

namespace Infrastructure.FilteringSystem.Product;

public record ProductStrictFilter
{
    public ProductStrictFilterProperty Property { get; }
    public string PropertyName => Property.ToString();
    public string Value { get; }

    public ProductStrictFilter(ProductStrictFilterProperty productProperty, string value)
    {
        Property = productProperty;
        Value = value;
    }

    public ProductStrictFilter(string productPropertyName, string value) 
        : this(EnumParser.Parse<ProductStrictFilterProperty>(productPropertyName), value)
    {
        
    }
}
using Api.SwaggerEnrichers.ProductStrictFilterView;

namespace Api.Controllers.ProductsControllers.Views;

public class ProductStrictFilterView
{
    [ProductStrictFilterPropertyName]
    public string PropertyName { get; }
    public string Value { get; }

    public ProductStrictFilterView(string propertyName, string value)
    {
        PropertyName = propertyName;
        Value = value;
    }
}
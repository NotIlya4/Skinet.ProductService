using Api.SwaggerEnrichers.GetProductsQueryView;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public required int Offset { get; init; }
    public required int Limit { get; init; }
    [ProductSortings]
    public IEnumerable<string>? Sortings { get; init; }
    [GetProductsProductType]
    public string? ProductType { get; init; }
    [GetProductsBrand]
    public string? Brand { get; init; }
    [GetProductsSearching]
    public string? Searching { get; init; }
}
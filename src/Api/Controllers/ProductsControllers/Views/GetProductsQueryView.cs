using Api.SwaggerEnrichers.GetProductsQueryView;

namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsQueryView
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    [ProductSortings]
    public IEnumerable<string>? Sortings { get; set; }
    [GetProductsProductType]
    public string? ProductType { get; set; }
    [GetProductsBrand]
    public string? Brand { get; set; }
    [GetProductsSearching]
    public string? Searching { get; set; }

    public GetProductsQueryView(int offset, int limit, IEnumerable<string>? sortings = null, string? productType = null, string? brand = null, string? searching = null)
    {
        Offset = offset;
        Limit = limit;
        Sortings = sortings;
        ProductType = productType;
        Brand = brand;
        Searching = searching;
    }

    public GetProductsQueryView()
    {
        
    }
}
namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsResultView
{
    public required List<ProductView> Products { get; init; }
    public required int Total { get; init; }
}
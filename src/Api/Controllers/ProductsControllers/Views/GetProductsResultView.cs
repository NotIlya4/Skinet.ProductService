namespace Api.Controllers.ProductsControllers.Views;

public class GetProductsResultView
{
    public List<ProductView> Products { get; }
    public int Total { get; }

    public GetProductsResultView(List<ProductView> products, int total)
    {
        Products = products;
        Total = total;
    }
}
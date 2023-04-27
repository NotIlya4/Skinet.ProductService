using Api.SwaggerEnrichers.ProductView;

namespace Api.Controllers.ProductsControllers.Views;

public class CreateProductCommandView
{
    [ProductName]
    public string Name { get; }
    [ProductDescription]
    public string Description { get; }
    [ProductPrice]
    public decimal Price { get; }
    [ProductPictureUrl]
    public Uri PictureUrl { get; }
    [ProductType]
    public string ProductType { get; }
    [ProductBrandName]
    public string Brand { get; }

    public CreateProductCommandView(string name, string description, decimal price, Uri pictureUrl, string productType, string brand)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }
}
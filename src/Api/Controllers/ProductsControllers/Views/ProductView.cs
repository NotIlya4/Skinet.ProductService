using Api.SwaggerEnrichers.ProductView;

namespace Api.Controllers.ProductsControllers.Views;

public class ProductView
{
    public Guid Id { get; }
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

    public ProductView(Guid id, string name, string description, decimal price, Uri pictureUrl, string productType, string brand)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }
}
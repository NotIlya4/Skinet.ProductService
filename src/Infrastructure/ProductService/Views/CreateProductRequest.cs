using Domain.Primitives;

namespace Infrastructure.ProductService.Views;

public class CreateProductRequest
{
    public Name Name { get; }
    public Description Description { get; }
    public Price Price { get; }
    public Uri PictureUrl { get; }
    public ProductType ProductType { get; }
    public Brand Brand { get; }

    public CreateProductRequest(Name name, Description description, Price price, Uri pictureUrl, ProductType productType, Brand brand)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }
}
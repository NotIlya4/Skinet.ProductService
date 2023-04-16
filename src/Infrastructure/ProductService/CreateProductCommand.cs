using Domain.Primitives;

namespace Infrastructure.ProductService;

public record CreateProductCommand
{
    public Name Name { get; }
    public Description Description { get; }
    public Price Price { get; }
    public Uri PictureUrl { get; }
    public Name ProductType { get; }
    public Name Brand { get; }

    public CreateProductCommand(Name name, Description description, Price price, Uri pictureUrl, Name productType, Name brand)
    {
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }
}
using Domain.Primitives;

namespace Domain.Entities;

public record Product
{
    public Guid Id { get; }
    public Name Name { get; }
    public Description Description { get; }
    public Price Price { get; }
    public Uri PictureUrl { get; }
    public ProductType ProductType { get; }
    public Brand Brand { get; }

    public Product(Guid id, Name name, Description description, Price price, Uri pictureUrl, ProductType productType, Brand brand)
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
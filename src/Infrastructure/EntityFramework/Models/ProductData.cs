namespace Infrastructure.EntityFramework.Models;

public class ProductData : IIdEquitable<ProductData>
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string PictureUrl { get; private set; }
    public ProductTypeData ProductType { get; private set; }
    public BrandData Brand { get; private set; }

    public ProductData(string id, string name, string description, decimal price, string pictureUrl, ProductTypeData productType, BrandData brand)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PictureUrl = pictureUrl;
        ProductType = productType;
        Brand = brand;
    }
    
    private ProductData()
    {
        Id = null!;
        Name = null!;
        Description = null!;
        PictureUrl = null!;
        ProductType = null!;
        Brand = null!;
    }

    public bool EqualId(ProductData entity)
    {
        return Id == entity.Id;
    }
}
using Domain.Interfaces;

namespace Infrastructure.EntityFramework.Models;

public class ProductTypeData : IEntityComparable<ProductTypeData>
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public ProductTypeData(string id, string name)
    {
        Id = id;
        Name = name;
    }

    private ProductTypeData()
    {
        Id = null!;
        Name = null!;
    }

    public bool EqualId(ProductTypeData entity)
    {
        return Id == entity.Id;
    }
}
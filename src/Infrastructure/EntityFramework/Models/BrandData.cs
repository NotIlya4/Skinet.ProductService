using Domain.Interfaces;

namespace Infrastructure.EntityFramework.Models;

public class BrandData : IEntityComparable<BrandData>
{
    public string Id { get; private set; }
    public string Name { get; private set; }

    public BrandData(string id, string name)
    {
        Id = id;
        Name = name;
    }

    private BrandData()
    {
        Id = null!;
        Name = null!;
    }

    public bool EqualId(BrandData entity)
    {
        return Id == entity.Id;
    }
}
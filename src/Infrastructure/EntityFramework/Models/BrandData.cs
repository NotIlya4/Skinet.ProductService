namespace Infrastructure.EntityFramework.Models;

public class BrandData : IIdEquitable<BrandData>
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public BrandData(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private BrandData()
    {
        Name = null!;
    }

    public bool EqualId(BrandData entity)
    {
        return Id == entity.Id;
    }
}
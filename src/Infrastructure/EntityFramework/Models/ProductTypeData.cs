namespace Infrastructure.EntityFramework.Models;

public class ProductTypeData : IIdEquitable<ProductTypeData>
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public ProductTypeData(int id, string name)
    {
        Id = id;
        Name = name;
    }

    private ProductTypeData()
    {
        Name = null!;
    }

    public bool EqualId(ProductTypeData entity)
    {
        return Id == entity.Id;
    }
}
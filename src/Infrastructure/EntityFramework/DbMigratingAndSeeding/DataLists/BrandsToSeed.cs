using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.DbMigratingAndSeeding.DataLists;

public class BrandsToSeed
{
    public BrandData Apple { get; }
    public BrandData Converse { get; }
    public BrandData Fitwear { get; }
    public BrandData Flexpants { get; }
    public BrandData Gildan { get; }
    public BrandData Hanes { get; }
    public List<BrandData> BrandDatas { get; }

    public BrandsToSeed()
    {
        Apple = new BrandData(1, "Apple");
        Converse = new BrandData(2, "Converse");
        Fitwear = new BrandData(3, "Fitwear");
        Flexpants = new BrandData(4, "Flexpants");
        Gildan = new BrandData(5, "Gildan");
        Hanes = new BrandData(6, "Hanes");
        BrandDatas = new List<BrandData>() { Apple, Converse, Fitwear, Flexpants, Gildan, Hanes };
    }
}
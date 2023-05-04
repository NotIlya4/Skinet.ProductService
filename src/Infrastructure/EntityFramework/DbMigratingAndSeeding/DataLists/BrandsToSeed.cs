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
        Apple = new BrandData(0, "Apple");
        Converse = new BrandData(0, "Converse");
        Fitwear = new BrandData(0, "Fitwear");
        Flexpants = new BrandData(0, "Flexpants");
        Gildan = new BrandData(0, "Gildan");
        Hanes = new BrandData(0, "Hanes");
        BrandDatas = new List<BrandData>() { Apple, Converse, Fitwear, Flexpants, Gildan, Hanes };
    }
}
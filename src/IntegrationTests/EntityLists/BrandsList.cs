using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class BrandsList
{
    public Brand Apple { get; }
    public BrandData AppleData { get; }
    
    public Brand McDonalds { get; }
    public BrandData McDonaldsData { get; }

    public IReadOnlyList<Brand> Brands { get; }
    public IReadOnlyList<BrandData> BrandDatas { get; }
    public JArray BrandsJArray { get; }

    public BrandsList()
    {
        string appleName = "Apple";
        Apple = new Brand(appleName);
        AppleData = new BrandData(id: 0, name: appleName);

        string mcDonaldsName = "McDonald's";
        McDonalds = new Brand(mcDonaldsName);
        McDonaldsData = new BrandData(id: 0, name: mcDonaldsName);

        Brands = new List<Brand>()
        {
            Apple,
            McDonalds
        };

        BrandDatas = new List<BrandData>()
        {
            AppleData,
            McDonaldsData
        };

        BrandsJArray = new JArray()
        {
            appleName,
            mcDonaldsName
        };
    }
}
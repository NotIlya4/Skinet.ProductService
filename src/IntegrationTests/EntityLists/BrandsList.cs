using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class BrandsList
{
    public Name Apple { get; }
    public BrandData AppleData { get; }
    
    public Name McDonalds { get; }
    public BrandData McDonaldsData { get; }

    public IReadOnlyList<Name> Brands { get; }
    public IReadOnlyList<BrandData> BrandDatas { get; }
    public JArray BrandsJArray { get; }

    public BrandsList()
    {
        string appleName = "Apple";
        Apple = new Name(appleName);
        AppleData = new BrandData(id: 0, name: appleName);

        string mcDonaldsName = "McDonald's";
        McDonalds = new Name(mcDonaldsName);
        McDonaldsData = new BrandData(id: 0, name: mcDonaldsName);

        Brands = new List<Name>()
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
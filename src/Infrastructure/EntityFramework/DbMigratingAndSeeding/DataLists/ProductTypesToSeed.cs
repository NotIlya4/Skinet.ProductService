using Infrastructure.EntityFramework.Models;

namespace Infrastructure.EntityFramework.DbMigratingAndSeeding.DataLists;

public class ProductTypesToSeed
{
    public ProductTypeData Pants { get; }
    public ProductTypeData Shoes { get; }
    public ProductTypeData Tshirt { get; }
    public ProductTypeData Watches { get; }
    public List<ProductTypeData> ProductTypeDatas { get; }

    public ProductTypesToSeed()
    {
        Pants = MakeProductType(0, "Pants");
        Shoes = MakeProductType(0, "Shoes");
        Tshirt = MakeProductType(0, "T-Shirt");
        Watches = MakeProductType(0, "Watches");
        ProductTypeDatas = new List<ProductTypeData>() { Pants, Shoes, Tshirt, Watches };
    }

    private ProductTypeData MakeProductType(int id, string name)
    {
        return new ProductTypeData(id: id, name: name);
    }
}
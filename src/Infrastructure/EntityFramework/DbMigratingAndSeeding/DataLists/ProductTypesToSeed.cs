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
        Pants = MakeProductType(1, "Pants");
        Shoes = MakeProductType(2, "Shoes");
        Tshirt = MakeProductType(3, "T-Shirt");
        Watches = MakeProductType(4, "Watches");
        ProductTypeDatas = new List<ProductTypeData>() { Pants, Shoes, Tshirt, Watches };
    }

    private ProductTypeData MakeProductType(int id, string name)
    {
        return new ProductTypeData(id: id, name: name);
    }
}
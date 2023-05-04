using Domain.Primitives;
using Infrastructure.EntityFramework.Models;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.EntityLists;

public class ProductTypesList
{
    public ProductType Smartphone { get; }
    public ProductTypeData SmartphoneData { get; }
    
    public ProductType Burger { get; }
    public ProductTypeData BurgerData { get; }

    public IReadOnlyList<ProductType> ProductTypes { get; }
    public IReadOnlyList<ProductTypeData> ProductTypeDatas { get; }
    public JArray ProductTypesJArray { get; }

    public ProductTypesList()
    {
        string smartphoneName = "Smartphone";
        Smartphone = new ProductType(smartphoneName);
        SmartphoneData = new ProductTypeData(id: 0, name: smartphoneName);

        string burgerName = "Burger";
        Burger = new ProductType(burgerName);
        BurgerData = new ProductTypeData(id: 0, name: burgerName);

        ProductTypes = new List<ProductType>()
        {
            Burger,
            Smartphone,
        };

        ProductTypeDatas = new List<ProductTypeData>()
        {
            BurgerData,
            SmartphoneData
        };
        
        ProductTypesJArray = new JArray()
        {
            burgerName,
            smartphoneName
        };
    }
}
using Infrastructure.FilteringSystem.Product;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsControllerGetProductTests
{
    private readonly ProductsControllerClient _client;
    private readonly ProductsList _productsList;
    
    public GetProductsControllerGetProductTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
        _productsList = fixture.ProductsList;
    }

    [Fact]
    public async Task ById_ProductWithSpecifiedId()
    {
        JObject product = await _client.GetProduct(ProductStrictFilterProperty.Id, _productsList.IBurger.Id.ToString());
        
        Assert.Equal(_productsList.IBurgerJObject, product);
    }
    
    [Fact]
    public async Task ByName_ProductWithSpecifiedName()
    {
        JObject product = await _client.GetProduct(ProductStrictFilterProperty.Name, _productsList.IPhone13.Name.ToString());
        
        Assert.Equal(_productsList.IPhone13JObject, product);
    }
}
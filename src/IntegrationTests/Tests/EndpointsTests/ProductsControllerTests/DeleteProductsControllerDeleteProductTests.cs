using Api.Controllers.ProductsControllers.Views;
using Infrastructure.FilteringSystem.Product;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class DeleteProductsControllerDeleteProductTests
{
    private readonly ProductsControllerClient _client;
    private readonly AppFixture _fixture;
    private readonly ProductsList _productsList;
    
    public DeleteProductsControllerDeleteProductTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
        _fixture = fixture;
        _productsList = fixture.ProductsList;
    }
    
    [Fact]
    public async Task ByName_DeleteProduct()
    {
        JArray expect = new()
        {
            _productsList.BigMacJObject,
            _productsList.IBurgerJObject,
            _productsList.IPhone13ProMaxJObject,
            _productsList.QuarterPounderJObject,
        };
        await _client.DeleteProduct(ProductStrictFilterProperty.Name, _fixture.ProductsList.IPhone13.Name.ToString());
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(0, 50));
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
    
    [Fact]
    public async Task ById_DeleteProduct()
    {
        JArray expect = new()
        {
            _productsList.BigMacJObject,
            _productsList.IBurgerJObject,
            _productsList.IPhone13JObject,
            _productsList.IPhone13ProMaxJObject,
        };
        await _client.DeleteProduct(ProductStrictFilterProperty.Id, _fixture.ProductsList.QuarterPounder.Id.ToString());
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(0, 50));
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
}
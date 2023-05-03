using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests.GetProductsControllerTests;

[Collection(nameof(AppFixture))]
public class GetProductsTests
{
    private readonly ProductsControllerClient _client;
    private readonly JArray _products;
    private readonly ProductsList _productsList;
    
    public GetProductsTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
        _products = fixture.ProductsList.ProductsJArray;
        _productsList = fixture.ProductsList;
    }

    [Fact]
    public async Task SeededProducts_ThatSeededProducts()
    {
        JObject response = await _client.GetProductsBase(new GetProductsRequestView());
        JArray productsResult = response["products"]?.Value<JArray>()!;
        int totalResult = response["total"]!.Value<int>()!;
        
        Assert.Equal(_products, productsResult);
        Assert.Equal(5, totalResult);
    }
    
    [Fact]
    public async Task Limit1_FirstProduct()
    {
        JArray expect = new()
        {
            _productsList.BigMacJObject
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(offset: 0, limit: 1));

        Assert.Equal(expect, result);
    }
    
    [Fact]
    public async Task Limit1Offset1_SecondProduct()
    {
        JArray expect = new()
        {
            _productsList.IBurgerJObject
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(offset: 1, limit: 1));

        Assert.Equal(expect, result);
    }
    
    [Fact]
    public async Task Limit1Offset1WithOtherFilters_SecondProductWithFilters()
    {
        JArray expect = new()
        {
            _productsList.IPhone13ProMaxJObject
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(offset: 1, limit: 1, brand: "Apple", searching: "iPhone"));

        Assert.Equal(expect, result);
    }
}
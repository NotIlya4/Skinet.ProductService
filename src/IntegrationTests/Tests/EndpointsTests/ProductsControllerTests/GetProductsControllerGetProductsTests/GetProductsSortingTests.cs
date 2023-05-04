using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests.GetProductsControllerGetProductsTests;

[Collection(nameof(AppFixture))]
public class GetProductsSortingTests
{
    private readonly ProductsControllerClient _client;
    private readonly ProductsList _productsList;
    
    public GetProductsSortingTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
        _productsList = fixture.ProductsList;
    }
    
    [Fact]
    public async Task NameDesc_SortedProducts()
    {
        JArray expect = new()
        {
            _productsList.QuarterPounderJObject,
            _productsList.IPhone13ProMaxJObject,
            _productsList.IPhone13JObject,
            _productsList.IBurgerJObject,
            _productsList.BigMacJObject,
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(sortings: new[] { "-name" }));

        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task PriceAsc_SortedProducts()
    {
        JArray expect = new()
        {
            _productsList.BigMacJObject,
            _productsList.QuarterPounderJObject,
            _productsList.IBurgerJObject,
            _productsList.IPhone13JObject,
            _productsList.IPhone13ProMaxJObject,
        };
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(sortings: new[] { "+price" }));

        Assert.Equal(expect, result);
    }
    
    [Fact]
    public async Task PriceDesc_SortedProducts()
    {
        JArray expect = new()
        {
            _productsList.IPhone13ProMaxJObject,
            _productsList.IPhone13JObject,
            _productsList.IBurgerJObject,
            _productsList.QuarterPounderJObject,
            _productsList.BigMacJObject,
        };
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(sortings: new[] { "-price" }));

        Assert.Equal(expect, result);
    }
}
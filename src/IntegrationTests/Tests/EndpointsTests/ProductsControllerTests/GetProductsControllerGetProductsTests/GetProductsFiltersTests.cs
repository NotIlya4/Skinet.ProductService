using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests.GetProductsControllerGetProductsTests;

[Collection(nameof(AppFixture))]
public class GetProductsFiltersTests
{
    private readonly ProductsControllerClient _client;
    private readonly ProductsList _productsList;
    
    public GetProductsFiltersTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
        _productsList = fixture.ProductsList;
    }
    
    [Fact]
    public async Task SpecifySearch_ProductsWithMatchingName()
    {
        JArray expect = new()
        {
            _productsList.IPhone13JObject,
            _productsList.IPhone13ProMaxJObject,
        };
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(searching: "iPhone"));

        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task SpecifyBrand_ProductsWithSpecifiedBrand()
    {
        JArray expect = new()
        {
            _productsList.IBurgerJObject,
            _productsList.IPhone13JObject,
            _productsList.IPhone13ProMaxJObject,
        };
        
        JArray result = await _client.GetProducts(new GetProductsRequestView(brand: "Apple"));

        Assert.Equal(expect, result);
    }
    
    [Fact]
    public async Task SpecifyProductType_ProductsWithSpecifiedProductType()
    {
        JArray expect = new()
        {
            _productsList.BigMacJObject,
            _productsList.IBurgerJObject,
            _productsList.QuarterPounderJObject,
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(productType: "Burger"));

        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task SpecifyProductTypeWithBrand_ProductsWithOverlapOfSpecifiedProductTypeAndBrand()
    {
        JArray expect = new()
        {
            _productsList.IBurgerJObject,
        };

        JArray result = await _client.GetProducts(new GetProductsRequestView(brand: "Apple", productType: "Burger"));

        Assert.Equal(expect, result);
    }
}
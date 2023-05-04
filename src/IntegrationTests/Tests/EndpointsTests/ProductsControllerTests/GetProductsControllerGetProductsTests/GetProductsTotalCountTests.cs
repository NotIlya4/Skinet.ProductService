using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests.GetProductsControllerGetProductsTests;

[Collection(nameof(AppFixture))]
public class GetProductsTotalCountTests
{
    private readonly ProductsControllerClient _client;
    
    public GetProductsTotalCountTests(AppFixture fixture)
    {
        _client = new ProductsControllerClient(fixture.Client);
    }

    [Fact]
    public async Task Limit1Offset1_CountRegardlessLimitAndOffset()
    {
        int result = await _client.GetProductsTotal(new GetProductsRequestView(1, 1));
        
        Assert.Equal(5, result);
    }

    [Fact]
    public async Task Filters_CountWithAppliedFilters()
    {
        int result = await _client.GetProductsTotal(new GetProductsRequestView(0, 50, brand: "Apple"));
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public async Task Limit1Offset1WithFilters_CountWithAppliedFiltersRegardlessLimitAndOffset()
    {
        int result = await _client.GetProductsTotal(new GetProductsRequestView(1, 1, brand: "Apple"));
        
        Assert.Equal(3, result);
    }
}
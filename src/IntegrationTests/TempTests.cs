using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;
using UriQueryStringComposer;

namespace IntegrationTests;

[Collection(nameof(AppFixture))]
public class TempTests
{
    private readonly AppFixture _fixture;
    private readonly BrandsList _brandsList;
    
    public TempTests(AppFixture fixture)
    {
        _fixture = fixture;
        _brandsList = fixture.BrandsList;
    }
    
    // [Fact]
    // public async Task Test()
    // {
    //     var request = new GetProductsRequestView(limit: 30);
    //
    //     Uri result = QueryStringComposer.Compose("http://localhost", request);
    //
    //     string pathAndQuery = result.PathAndQuery;
    // }
}
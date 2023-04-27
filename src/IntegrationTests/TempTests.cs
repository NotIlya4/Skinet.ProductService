using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Clients;
using IntegrationTests.Fixtures;
using Newtonsoft.Json.Linq;

namespace IntegrationTests;

[Collection(nameof(AppFixture))]
public class TempTests
{
    public AppFixture AppFixture { get; }
    
    public TempTests(AppFixture appFixture)
    {
        AppFixture = appFixture;
    }
    
    // [Fact]
    public async Task Test()
    {
        
    }
}
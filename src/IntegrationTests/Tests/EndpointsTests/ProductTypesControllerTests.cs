using IntegrationTests.Clients;
using IntegrationTests.EntityLists;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests;

[Collection(nameof(AppFixture))]
public class ProductTypesControllerTests
{
    private readonly JArray _productTypes;
    private readonly ProductTypesControllerClient _client;
    private readonly AppFixture _fixture;

    public ProductTypesControllerTests(AppFixture fixture)
    {
        _client = new ProductTypesControllerClient(fixture.Client);
        _productTypes = fixture.ProductTypesList.ProductTypesJArray;
        _fixture = fixture;
    }
    
    [Fact]
    public async Task GetProductTypes_ReturnProductTypes()
    {
        JArray result = await _client.GetProductTypes();

        Assert.Equal(_productTypes, result);
    }
    
    [Fact]
    public async Task AddProductType_ReturnPersistedProductType()
    {
        string newProductType = "Door";
        await _client.Add(newProductType);
        JArray expect = new JArray(_productTypes);
        expect.Insert(1, newProductType);
        
        JArray result = await _client.GetProductTypes();
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
    
    [Fact]
    public async Task DeleteProductType_DeleteProductType()
    {
        var expect = new JArray(_productTypes);
        expect.Remove(expect.First(t => t.Value<string>() == "Smartphone"));
        await _client.Delete("Smartphone");
        
        JArray result = await _client.GetProductTypes();
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
}
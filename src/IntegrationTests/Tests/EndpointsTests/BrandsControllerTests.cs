using IntegrationTests.Clients;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests;

[Collection(nameof(AppFixture))]
public class BrandsControllerTests
{
    private readonly JArray _brands;
    private readonly BrandsControllerClient _client;
    private readonly AppFixture _fixture;

    public BrandsControllerTests(AppFixture fixture)
    {
        _client = new BrandsControllerClient(fixture.Client);
        _brands = fixture.BrandsList.BrandsJArray;
        _fixture = fixture;
    }

    [Fact]
    public async Task GetBrands_SeededBrands_ThatSeededBrands()
    {
        JArray result = await _client.GetBrands();

        Assert.Equal(_brands, result);
    }

    [Fact]
    public async Task Add_AddNewBrand_SeededBrandsWithNewOneInAlphabeticalOrder()
    {
        string newBrand = "Barbie";
        await _client.Add(newBrand);
        JArray expect = new JArray(_brands);
        expect.Insert(1, newBrand);
        
        JArray result = await _client.GetBrands();
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }

    [Fact]
    public async Task Delete_ExistingBrand_SeededBrandsWithoutDeletedOne()
    {
        var expect = new JArray(_brands);
        expect.Remove(expect.First(t => t.Value<string>() == "Apple"));
        await _client.Delete("Apple");
        
        JArray result = await _client.GetBrands();
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
}
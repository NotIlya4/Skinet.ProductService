using IntegrationTests.Clients;
using IntegrationTests.Extensions;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Tests.EndpointsTests.ProductsControllerTests;

[Collection(nameof(AppFixture))]
public class CreateProductsControllerCreateProductTests
{
    private readonly ProductsControllerClient _client;
    private readonly JArray _products;
    private readonly AppFixture _fixture;
    
    public CreateProductsControllerCreateProductTests(AppFixture fixture)
    {
        _products = fixture.ProductsList.ProductsJArray;
        _client = new ProductsControllerClient(fixture.Client);
        _fixture = fixture;
    }

    [Fact]
    public async Task AddNewProduct_ReturnPersistedProduct()
    {
        JObject newProduct = new JObject()
        {
            ["name"] = "Samsung Galaxy S21",
            ["description"] =
                "The Samsung Galaxy S21 is a high-end smartphone with a 6.2-inch display and a triple-lens rear camera system.",
            ["price"] = 999.99m,
            ["pictureUrl"] = "https://example.com/product.jpg",
            ["productType"] = "Smartphone",
            ["brand"] = "Apple"
        };
        JObject returnProduct = await _client.CreateProduct(newProduct);
        newProduct["id"] = returnProduct.String("id");
        
        Assert.True(JToken.DeepEquals(newProduct, returnProduct));

        JArray expect = new JArray(_products);
        expect.Add(returnProduct);

        JArray result = await _client.GetProducts();
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
}
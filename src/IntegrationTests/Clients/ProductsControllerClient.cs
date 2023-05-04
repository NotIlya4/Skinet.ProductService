using Api.Controllers.ProductsControllers.Views;
using Infrastructure.FilteringSystem.Product;
using IntegrationTests.Extensions;
using Newtonsoft.Json.Linq;
using UriQueryStringComposer;

namespace IntegrationTests.Clients;

public class ProductsControllerClient
{
    public HttpClient Client { get; }
    
    public ProductsControllerClient(HttpClient client)
    {
        Client = client;
    }

    public async Task<JObject> CreateProduct(JObject jObject)
    {
        HttpContent httpContent = new StringContent(jObject.ToString(), System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage response = await Client.PostAsync("products", httpContent);
        response.EnsureSuccessStatusCode();
        return await response.ExtractJObject();
    }

    public async Task<JObject> CreateProduct(CreateProductRequestView view)
    {
        return await CreateProduct(JObject.FromObject(view));
    }

    public async Task<JObject> GetProduct(ProductStrictFilterProperty property, string value)
    {
        return await Client.GetAsync($"products/{property.ToString()}/{value}").ExtractJObject();
    }

    public async Task DeleteProduct(ProductStrictFilterProperty property, string value)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"products/{property.ToString()}/{value}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JObject> GetProductsBase(GetProductsRequestView? requestView = null)
    {
        string pathAndQuery = QueryStringComposer.Compose("http://localhost/products", requestView).PathAndQuery;
        
        var response = await Client.GetAsync(pathAndQuery);
        response.EnsureSuccessStatusCode();

        return await response.ExtractJObject();
    }

    public async Task<JArray> GetProducts(GetProductsRequestView? requestView = null)
    {
        JObject response = await GetProductsBase(requestView);
        return response["products"]?.Value<JArray>()!;
    }

    public async Task<int> GetProductsTotal(GetProductsRequestView? requestView = null)
    {
        JObject response = await GetProductsBase(requestView);
        return response.Int("total");
    }
}
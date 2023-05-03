using IntegrationTests.Extensions;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class ProductTypesControllerClient
{
    public HttpClient Client { get; }
    
    public ProductTypesControllerClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Add(string productTypeName)
    {
        HttpResponseMessage response = await Client.PostAsync($"products/product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JArray> GetProductTypes()
    {
        HttpResponseMessage response = await Client.GetAsync("products/product-types");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task Delete(string productTypeName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"products/product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }
}
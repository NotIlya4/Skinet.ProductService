using IntegrationTests.Extensions;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class ProductTypesClient
{
    public HttpClient Client { get; }
    
    public ProductTypesClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Add(string productTypeName)
    {
        HttpResponseMessage response = await Client.PostAsync($"product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JArray> GetProductTypes()
    {
        HttpResponseMessage response = await Client.GetAsync("product-types");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task Delete(string productTypeName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"product-types/{productTypeName}");
        response.EnsureSuccessStatusCode();
    }
}
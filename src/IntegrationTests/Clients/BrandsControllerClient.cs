using IntegrationTests.Extensions;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class BrandsControllerClient
{
    public HttpClient Client { get; }
    
    public BrandsControllerClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Add(string brandName)
    {
        HttpResponseMessage response = await Client.PostAsync($"products/brands/{brandName}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JArray> GetBrands()
    {
        HttpResponseMessage response = await Client.GetAsync("products/brands");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task Delete(string brandName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"products/brands/{brandName}");
        response.EnsureSuccessStatusCode();
    }
}
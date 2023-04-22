using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class BrandsClient
{
    public HttpClient Client { get; }
    
    public BrandsClient(HttpClient client)
    {
        Client = client;
    }
    
    public async Task Add(string brandName)
    {
        HttpResponseMessage response = await Client.PostAsync($"brands/{brandName}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<JArray> GetBrands()
    {
        HttpResponseMessage response = await Client.GetAsync("brands");
        response.EnsureSuccessStatusCode();
        
        return await response.ExtractJArray();
    }
    
    public async Task Delete(string brandName)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"brands/{brandName}");
        response.EnsureSuccessStatusCode();
    }
}
using Api.Controllers.ProductsControllers.Views;
using IntegrationTests.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace IntegrationTests.Clients;

public class ProductsClient
{
    public HttpClient Client { get; }
    
    public ProductsClient(HttpClient client)
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

    public async Task<JObject> GetProductsBase(GetProductsRequestView getProductsRequestView)
    {
        List<KeyValuePair<string, string?>> queryStringDict = new();

        queryStringDict.Add(new("limit", getProductsRequestView.Limit.ToString()));
        queryStringDict.Add(new("offset", getProductsRequestView.Offset.ToString()));

        if (getProductsRequestView.Sortings is not null)
        {
            foreach (var sorting in getProductsRequestView.Sortings)
            {
                queryStringDict.Add(new("sortings", sorting));
            }
        }

        queryStringDict.Add(new("productType", getProductsRequestView.ProductType));
        queryStringDict.Add(new("brand", getProductsRequestView.Brand));
        queryStringDict.Add(new("searching", getProductsRequestView.Searching));

        string? queryString = QueryString.Create(queryStringDict).Value;

        var response = await Client.GetAsync($"products{queryString}");
        response.EnsureSuccessStatusCode();

        return await response.ExtractJObject();
    }

    public async Task<JArray> GetProducts(GetProductsRequestView getProductsRequestView)
    {
        JObject response = await GetProductsBase(getProductsRequestView);
        return response["products"]?.Value<JArray>()!;
    }
    
    public async Task<int> GetProductsTotal(GetProductsRequestView getProductsRequestView)
    {
        JObject response = await GetProductsBase(getProductsRequestView);
        return response.Int("total");
    }

    public async Task<JObject> GetProduct(string propertyName, string value)
    {
        return await Client.GetAsync($"products/{propertyName}/{value}").ExtractJObject();
    }

    public async Task DeleteProduct(string propertyName, string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"products/{propertyName}/{id}");
        response.EnsureSuccessStatusCode();
    }
}
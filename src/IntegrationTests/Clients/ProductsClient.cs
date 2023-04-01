﻿using Api.Controllers.ProductsControllers.Views;
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
        HttpResponseMessage response = await Client.PostAsync("api/products", httpContent);
        response.EnsureSuccessStatusCode();
        return await response.ExtractJObject();
    }

    public async Task<JObject> GetProducts(GetProductsQueryView getProductsQueryView)
    {
        List<KeyValuePair<string, string?>> queryStringDict = new();

        queryStringDict.Add(new("limit", getProductsQueryView.Limit.ToString()));
        queryStringDict.Add(new("offset", getProductsQueryView.Offset.ToString()));

        if (getProductsQueryView.Sortings is not null)
        {
            foreach (var sorting in getProductsQueryView.Sortings)
            {
                queryStringDict.Add(new("sortings", sorting));
            }
        }

        if (getProductsQueryView.ProductTypeName is not null)
        {
            queryStringDict.Add(new("productTypeName", getProductsQueryView.ProductTypeName));
        }
        
        if (getProductsQueryView.BrandName is not null)
        {
            queryStringDict.Add(new("brandName", getProductsQueryView.BrandName));
        }
        
        if (getProductsQueryView.Searching is not null)
        {
            queryStringDict.Add(new("searching", getProductsQueryView.Searching));
        }

        string? queryString = QueryString.Create(queryStringDict).Value;

        var response = await Client.GetAsync($"api/products{queryString}");
        response.EnsureSuccessStatusCode();

        return await response.ExtractJObject();
    }

    public async Task DeleteProduct(string id)
    {
        HttpResponseMessage response = await Client.DeleteAsync($"api/products/id/{id}");
        response.EnsureSuccessStatusCode();
    }
}
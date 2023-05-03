using Newtonsoft.Json.Linq;

namespace IntegrationTests.Extensions;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> PostAsync(this HttpClient client, string url)
    {
        return client.PostAsync(url, null);
    }

    public static async Task<JObject> ExtractJObject(this Task<HttpResponseMessage> responseMessage)
    {
        HttpResponseMessage response = await responseMessage;
        return await response.ExtractJObject();
    }
    
    public static async Task<JArray> ExtractJArray(this Task<HttpResponseMessage> responseMessage)
    {
        HttpResponseMessage response = await responseMessage;
        return await response.ExtractJArray();
    }

    public static async Task<JObject> ExtractJObject(this HttpResponseMessage response)
    {
        string body = await response.Content.ReadAsStringAsync();
        return JObject.Parse(body);
    }
    
    public static async Task<JArray> ExtractJArray(this HttpResponseMessage response)
    {
        string body = await response.Content.ReadAsStringAsync();
        return JArray.Parse(body);
    }
}
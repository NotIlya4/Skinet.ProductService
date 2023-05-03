using Newtonsoft.Json.Linq;

namespace IntegrationTests.Extensions;

public static class JTokenExtensions
{
    public static string String(this JToken jToken, string key)
    {
        return jToken[key]!.Value<string>()!;
    }
    
    public static int Int(this JToken jToken, string key)
    {
        return jToken[key]!.Value<int>()!;
    }
}
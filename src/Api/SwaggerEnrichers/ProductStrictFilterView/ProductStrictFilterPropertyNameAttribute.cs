using Infrastructure.FilteringSystem.Product;
using Infrastructure.Misc;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.SwaggerEnrichers.ProductStrictFilterView;

public class ProductStrictFilterPropertyNameAttribute : EnricherBaseAttribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        parameter.Description = $"Available are: {Enum.GetNames(typeof(ProductStrictFilterProperty)).Select(s => s.ToLower()).ToReadableString()}";
    }
}
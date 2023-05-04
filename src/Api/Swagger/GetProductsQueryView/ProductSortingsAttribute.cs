using Infrastructure.SortingSystem.Product;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.Swagger.GetProductsQueryView;

public class ProductSortingsAttribute : EnricherBaseAttribute, IParameterEnricher
{
    public void Enrich(OpenApiParameter parameter)
    {
        List<string> strings = Enum.GetNames<ProductSortingProperty>().Select(s => s.ToLower())
            .SelectMany(s => new List<string>() { $"+{s}", $"-{s}" }).ToList();
        
        parameter.Description = string.Join(", ", strings);
        parameter.Schema.Items.Default = new OpenApiString("");
    }
}
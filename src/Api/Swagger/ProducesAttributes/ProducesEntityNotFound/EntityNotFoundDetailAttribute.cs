using Infrastructure.Repositories.Exceptions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using SwaggerEnrichers.CreateCustomEnrichers;

namespace Api.Swagger.ProducesAttributes.ProducesEntityNotFound;

public class EntityNotFoundDetailAttribute : EnricherBaseAttribute, ISchemaEnricher
{
    public void Enrich(OpenApiSchema schema)
    {
        schema.Example = new OpenApiString(new EntityNotFoundException("Entity").Message);
    }
}
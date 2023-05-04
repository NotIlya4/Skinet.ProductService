namespace Api.Swagger.ProducesAttributes.ProducesEntityNotFound;

public class EntityNotFoundExceptionView
{
    [EntityNotFoundTitle]
    public required string Title { get; init; }
    [EntityNotFoundDetail]
    public required string Detail { get; init; }
}
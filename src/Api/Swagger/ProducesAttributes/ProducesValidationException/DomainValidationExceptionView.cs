namespace Api.Swagger.ProducesAttributes.ProducesValidationException;

public class DomainValidationExceptionView
{
    [DomainValidationExceptionTitle]
    public required string Title { get; init; }
    [DomainValidationExceptionDetail]
    public required string Detail { get; init; }
}
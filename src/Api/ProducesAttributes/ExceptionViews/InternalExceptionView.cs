using Api.SwaggerEnrichers.InternalExceptionView;

namespace Api.ProducesAttributes.ExceptionViews;

public class InternalExceptionView
{
    [InternalExceptionTitle]
    public required string Title { get; init; }
    [InternalExceptionDetail]
    public required string Detail { get; init; }
}
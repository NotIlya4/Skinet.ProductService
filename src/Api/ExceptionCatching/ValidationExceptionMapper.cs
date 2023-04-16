using Domain.Exceptions;
using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;

namespace Api.ExceptionCatching;

public class ValidationExceptionMapper : IExceptionMapper<DomainValidationException>
{
    public BadResponse Map(DomainValidationException exception)
    {
        return new BadResponse()
        {
            StatusCode = 400,
            ResponseDto = new BadResponseDto()
            {
                Title = "Validation exception",
                Detail = exception.Message
            }
        };
    }
}
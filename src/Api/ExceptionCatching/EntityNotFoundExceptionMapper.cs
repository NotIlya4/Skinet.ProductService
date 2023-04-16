using ExceptionCatcherMiddleware.Mappers.CreatingCustomMappers;
using Infrastructure.Repositories.Exceptions;

namespace Api.ExceptionCatching;

public class EntityNotFoundExceptionMapper : IExceptionMapper<EntityNotFoundException>
{
    public BadResponse Map(EntityNotFoundException exception)
    {
        return new BadResponse()
        {
            StatusCode = StatusCodes.Status404NotFound,
            ResponseDto = new BadResponseDto()
            {
                Title = "Entity not found",
                Detail = exception.Message
            }
        };
    }
}
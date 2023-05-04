using Microsoft.AspNetCore.Mvc;

namespace Api.Swagger.ProducesAttributes.ProducesEntityNotFound;

public class ProducesEntityNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesEntityNotFoundAttribute() : base(typeof(EntityNotFoundExceptionView), StatusCodes.Status404NotFound)
    {
        
    }
}
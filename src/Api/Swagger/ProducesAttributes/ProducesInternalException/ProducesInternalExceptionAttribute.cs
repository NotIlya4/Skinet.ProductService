using Microsoft.AspNetCore.Mvc;

namespace Api.Swagger.ProducesAttributes.ProducesInternalException;

public class ProducesInternalExceptionAttribute : ProducesResponseTypeAttribute
{
    public ProducesInternalExceptionAttribute() 
        : base(typeof(InternalExceptionView), StatusCodes.Status500InternalServerError)
    {
        
    }
}
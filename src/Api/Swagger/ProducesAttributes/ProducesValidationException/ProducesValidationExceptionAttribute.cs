using Microsoft.AspNetCore.Mvc;

namespace Api.Swagger.ProducesAttributes.ProducesValidationException;

public class ProducesValidationExceptionAttribute : ProducesResponseTypeAttribute
{
    public ProducesValidationExceptionAttribute() : base(typeof(DomainValidationExceptionView), StatusCodes.Status400BadRequest)
    {
        
    }
}
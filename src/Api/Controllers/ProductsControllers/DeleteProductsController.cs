using Api.Swagger.ProducesAttributes;
using Api.Swagger.ProducesAttributes.ProducesEntityNotFound;
using Api.Swagger.ProducesAttributes.ProducesInternalException;
using Api.Swagger.ProducesAttributes.ProducesValidationException;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
[Route("products")]
[ApiController]
[ProducesInternalException]
[ProducesEntityNotFound]
[ProducesNoContent]
[ProducesValidationException]
public class DeleteProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public DeleteProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpDelete]
    [Route("id/{id}")]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        await _productService.DeleteProduct(new ProductStrictFilter(ProductStrictFilterProperty.Id, id));
        return NoContent();
    }
    
    [HttpDelete]
    [Route("name/{name}")]
    public async Task<IActionResult> DeleteProductByName(string name)
    {
        await _productService.DeleteProduct(new ProductStrictFilter(ProductStrictFilterProperty.Name, name));
        return NoContent();
    }
}
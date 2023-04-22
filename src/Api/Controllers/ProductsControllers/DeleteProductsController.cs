using Api.ProducesAttributes;
using Api.SwaggerEnrichers.ProductStrictFilterView;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
[Route("products")]
[ApiController]
[ProducesInternalException]
public class DeleteProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public DeleteProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpDelete]
    [Route("id/{id}")]
    [ProducesEntityNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProductById(string id)
    {
        await _productService.DeleteProduct(ProductStrictFilterProperty.Id, id);
        return NoContent();
    }
    
    [HttpDelete]
    [Route("name/{name}")]
    [ProducesEntityNotFound]
    [ProducesNoContent]
    public async Task<IActionResult> DeleteProductByName(string name)
    {
        await _productService.DeleteProduct(ProductStrictFilterProperty.Name, name);
        return NoContent();
    }
}
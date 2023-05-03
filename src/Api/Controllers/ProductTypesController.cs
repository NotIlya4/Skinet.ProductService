using Api.ProducesAttributes;
using Domain.Primitives;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("ProductTypes")]
[Route("products/product-types")]
[ApiController]
[ProducesInternalException]
public class ProductTypesController : ControllerBase
{
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductTypesController(IProductTypeRepository productTypeRepository)
    {
        _productTypeRepository = productTypeRepository;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<IEnumerable<string>>> GetProductTypes()
    {
        List<Name> productTypes = await _productTypeRepository.Get();
        return Ok(productTypes.Select(p => p.Value));
    }

    [HttpPost]
    [Route("{productType}")]
    [ProducesNoContent]
    public async Task<ActionResult> Add(string productType)
    {
        await _productTypeRepository.Add(new Name(productType));
        return NoContent();
    }

    [HttpDelete]
    [Route("{productType}")]
    [ProducesNoContent]
    public async Task<ActionResult> Delete(string productType)
    {
        await _productTypeRepository.Delete(new Name(productType));
        return NoContent();
    }
}
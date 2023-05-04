using Api.Swagger.ProducesAttributes;
using Api.Swagger.ProducesAttributes.ProducesInternalException;
using Api.Swagger.ProducesAttributes.ProducesValidationException;
using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Tags("Brands")]
[Route("products/brands")]
[ApiController]
[ProducesInternalException]
public class BrandsController : ControllerBase
{
    private readonly IBrandRepository _brandRepository;

    public BrandsController(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
    
    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<List<string>>> GetBrands()
    {
        List<Brand> brands = await _brandRepository.Get();
        return Ok(brands.Select(b => b.Value).ToList());
    }

    [HttpPost]
    [Route("{brand}")]
    [ProducesNoContent]
    [ProducesValidationException]
    public async Task<ActionResult> Add(string brand)
    {
        await _brandRepository.Add(new Brand(brand));
        return NoContent();
    }

    [HttpDelete]
    [Route("{brand}")]
    [ProducesNoContent]
    [ProducesValidationException]
    public async Task<ActionResult> Delete(string brand)
    {
        await _brandRepository.Delete(new Brand(brand));
        return NoContent();
    }
}
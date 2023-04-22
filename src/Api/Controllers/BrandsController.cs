using Api.ProducesAttributes;
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
        List<Name> brands = await _brandRepository.GetBrands();
        return Ok(brands.Select(b => b.Value).ToList());
    }

    [HttpPost]
    [Route("{brand}")]
    [ProducesNoContent]
    public async Task<ActionResult> Add(string brand)
    {
        await _brandRepository.Add(new Name(brand));
        return NoContent();
    }

    [HttpDelete]
    [Route("{brand}")]
    [ProducesNoContent]
    public async Task<ActionResult> Delete(string brand)
    {
        await _brandRepository.Delete(new Name(brand));
        return NoContent();
    }
}
using Api.Controllers.ProductsControllers.Helpers;
using Api.Controllers.ProductsControllers.Views;
using Api.ProducesAttributes;
using Api.SwaggerEnrichers.ProductStrictFilterView;
using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
[Route("products")]
[ApiController]
[ProducesInternalException]
public class GetProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ViewMapper _mapper;

    public GetProductsController(IProductService productService, ViewMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesOk]
    public async Task<ActionResult<GetProductsResultView>> GetProducts([FromQuery] GetProductsQueryView queryView)
    {
        GetProductsQuery query = _mapper.MapGetProductsQuery(queryView);
        GetProductsResult result = await _productService.GetProducts(query);
        GetProductsResultView resultView = _mapper.MapGetProductsResult(result);
        
        return Ok(resultView);
    }

    [HttpGet]
    [Route("id/{id}")]
    [ProducesOk]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProductById(string id)
    {
        Product product = await _productService.GetProduct(ProductStrictFilterProperty.Id, id);
        ProductView productView = _mapper.MapProduct(product);
        
        return Ok(productView);
    }
    
    [HttpGet]
    [Route("name/{name}")]
    [ProducesOk]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProductByName(string name)
    {
        Product product = await _productService.GetProduct(ProductStrictFilterProperty.Name, name);
        ProductView productView = _mapper.MapProduct(product);
        
        return Ok(productView);
    }
}
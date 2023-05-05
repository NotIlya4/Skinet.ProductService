using Api.Controllers.ProductsControllers.Helpers;
using Api.Controllers.ProductsControllers.Views;
using Api.Swagger.ProducesAttributes;
using Api.Swagger.ProducesAttributes.ProducesEntityNotFound;
using Api.Swagger.ProducesAttributes.ProducesInternalException;
using Api.Swagger.ProducesAttributes.ProducesValidationException;
using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.ProductService.Views;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
[Route("products")]
[ApiController]
[ProducesInternalException]
[ProducesOk]
[ProducesValidationException]
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
    public async Task<ActionResult<GetProductsResultView>> GetProducts([FromQuery] GetProductsRequestView requestView)
    {
        GetProductsRequest request = _mapper.MapGetProductsRequest(requestView);
        GetProductsResult result = await _productService.GetProducts(request);
        GetProductsResultView resultView = _mapper.MapGetProductsResult(result);

        return Ok(resultView);
    }

    [HttpGet]
    [Route("id/{id}")]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProductById(string id)
    {
        Product product = await _productService.GetProduct(new ProductStrictFilter(ProductStrictFilterProperty.Id, id));
        ProductView productView = _mapper.MapProduct(product);
        
        return Ok(productView);
    }
    
    [HttpGet]
    [Route("name/{name}")]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProductByName(string name)
    {
        Product product = await _productService.GetProduct(new ProductStrictFilter(ProductStrictFilterProperty.Name, name));
        ProductView productView = _mapper.MapProduct(product);
        
        return Ok(productView);
    }
}
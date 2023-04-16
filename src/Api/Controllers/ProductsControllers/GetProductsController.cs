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
public class GetProductsController : ProductsControllerBase
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
        List<ProductView> productViews = _mapper.MapProduct(result.Products);
        
        return Ok(new GetProductsResultView()
        {
            Products = productViews,
            Total = result.Total
        });
    }

    [HttpGet]
    [Route("{propertyName}/{value}")]
    [ProducesOk]
    [ProducesEntityNotFound]
    public async Task<ActionResult<ProductView>> GetProduct([ProductStrictFilterPropertyName] string propertyName, string value)
    {
        Product product = await _productService.GetProduct(new ProductStrictFilter(
            productPropertyName: propertyName, 
            expectedValue: value));
        ProductView productView = _mapper.MapProduct(product);
        return Ok(productView);
    }
}
using Api.Controllers.ProductsControllers.Helpers;
using Api.Controllers.ProductsControllers.Views;
using Api.Swagger.ProducesAttributes;
using Api.Swagger.ProducesAttributes.ProducesInternalException;
using Api.Swagger.ProducesAttributes.ProducesValidationException;
using Domain.Entities;
using Infrastructure.ProductService;
using Infrastructure.ProductService.Views;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ProductsControllers;

[Tags("Products")]
[Route("products")]
[ApiController]
[ProducesInternalException]
[ProducesValidationException]
[ProducesOk]
public class CreateProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly ViewMapper _mapper;

    public CreateProductsController(IProductService productService, ViewMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<ProductView>> CreateProduct(CreateProductRequestView requestView)
    {
        CreateProductRequest request = _mapper.MapCreateProductRequest(requestView);
        Product product = await _productService.CreateNewProduct(request);
        ProductView productView = _mapper.MapProduct(product);
        return Ok(productView);
    }
}
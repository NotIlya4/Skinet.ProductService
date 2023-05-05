using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService.Views;
using Infrastructure.Repositories.ProductRepository;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Infrastructure.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Product> GetProduct(ProductStrictFilter filter)
    {
        return await _productRepository.GetProduct(filter);
    }

    public async Task<Product> CreateNewProduct(CreateProductRequest request)
    {
        Product product = new Product(
            id: Guid.NewGuid(),
            name: request.Name,
            description: request.Description,
            price: request.Price,
            pictureUrl: request.PictureUrl,
            productType: request.ProductType,
            brand: request.Brand);

        await _productRepository.Insert(product);
        using (LogContext.PushProperty("Product", product))
        {
            _logger.LogInformation("New product {ProductName} created", product.Name.Value);
        }

        return product;
    }

    public async Task DeleteProduct(ProductStrictFilter filter)
    {
        using (LogContext.PushProperty("Filter", filter))
        {
            _logger.LogInformation("Product with {Property} {Value} has been deleted", filter.PropertyName, filter.Value);
        }
        await _productRepository.Delete(filter);
    }

    public async Task<GetProductsResult> GetProducts(GetProductsRequest request)
    {
        List<Product> products = await _productRepository.GetProducts(request);
        int total = await _productRepository.GetCount(request.Filters);
        return new GetProductsResult(products: products, total: total);
    }
}
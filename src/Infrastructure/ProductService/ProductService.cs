using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.ProductRepository;

namespace Infrastructure.ProductService;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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

        return product;
    }

    public async Task DeleteProduct(ProductStrictFilter filter)
    {
        await _productRepository.Delete(filter);
    }

    public async Task<GetProductsResult> GetProducts(GetProductsRequest request)
    {
        List<Product> products = await _productRepository.GetProducts(request);
        int total = await _productRepository.GetCount(request.Filters);
        return new GetProductsResult(products: products, total: total);
    }
}
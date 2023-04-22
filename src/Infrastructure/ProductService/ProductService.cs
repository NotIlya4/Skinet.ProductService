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

    public async Task<Product> GetProduct(ProductStrictFilterProperty property, string value)
    {
        return await _productRepository.GetProduct(new ProductStrictFilter(property, value));
    }

    public async Task<Product> CreateNewProduct(CreateProductCommand createProductCommand)
    {
        Product product = new Product(
            id: Guid.NewGuid(),
            name: createProductCommand.Name,
            description: createProductCommand.Description,
            price: createProductCommand.Price,
            pictureUrl: createProductCommand.PictureUrl,
            productType: createProductCommand.ProductType,
            brand: createProductCommand.Brand);

        await _productRepository.Insert(product);

        return product;
    }

    public async Task DeleteProduct(ProductStrictFilterProperty property, string value)
    {
        await _productRepository.Delete(new ProductStrictFilter(property, value));
    }

    public async Task<GetProductsResult> GetProducts(GetProductsQuery query)
    {
        List<Product> products = await _productRepository.GetProducts(query);
        int total = await _productRepository.GetProductsCountForFilters(query.FluentFilters);
        return new GetProductsResult(products: products, total: total);
    }
}
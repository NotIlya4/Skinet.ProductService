using Domain.Entities;
using Infrastructure.FilteringSystem.Product;

namespace Infrastructure.ProductService;

public interface IProductService
{
    public Task<GetProductsResult> GetProducts(GetProductsQuery query);
    public Task<Product> GetProduct(ProductStrictFilterProperty property, string value);
    public Task<Product> CreateNewProduct(CreateProductCommand createProductCommand);
    public Task DeleteProduct(ProductStrictFilterProperty property, string value);
}
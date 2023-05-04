using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService.Views;

namespace Infrastructure.ProductService;

public interface IProductService
{
    public Task<GetProductsResult> GetProducts(GetProductsRequest request);
    public Task<Product> GetProduct(ProductStrictFilter filter);
    public Task<Product> CreateNewProduct(CreateProductRequest request);
    public Task DeleteProduct(ProductStrictFilter filter);
}
using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;

namespace Infrastructure.Repositories.ProductRepository;

public interface IProductRepository
{
    public Task<Product> GetProduct(ProductStrictFilter filter);
    public Task<List<Product>> GetProducts(GetProductsRequest request);
    public Task<int> GetCount(ProductFluentFilters filters);
    public Task Insert(Product product);
    public Task Delete(ProductStrictFilter filter);
}
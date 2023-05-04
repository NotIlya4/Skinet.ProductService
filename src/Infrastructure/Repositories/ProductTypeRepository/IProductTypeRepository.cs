using Domain.Primitives;

namespace Infrastructure.Repositories.ProductTypeRepository;

public interface IProductTypeRepository
{
    public Task<List<ProductType>> Get();
    public Task Add(ProductType productType);
    public Task Delete(ProductType productType);
}
using Domain.Primitives;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<List<Brand>> Get();
    public Task Add(Brand brand);
    public Task Delete(Brand brand);
}
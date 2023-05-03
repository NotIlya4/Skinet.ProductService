using Domain.Primitives;
using Infrastructure.Repositories.BrandRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests;

[Collection(nameof(AppFixture))]
public class BrandRepositoryTests : IDisposable
{
    private readonly IBrandRepository _repository;
    private readonly IServiceScope _scope;
    private readonly List<Name> _brands;
    private readonly AppFixture _fixture;

    public BrandRepositoryTests(AppFixture fixture)
    {
        _fixture = fixture;
        _brands = fixture.BrandsList.Brands.ToList();
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IBrandRepository>();
    }

    [Fact]
    public async Task Get_SeededEntities_ThatSeededEntities()
    {
        List<Name> result = await _repository.Get();
        
        Assert.Equal(_brands, result);
    }

    [Fact]
    public async Task Add_AddNewBrand_SeededBrandsWithNewOneInAlphabeticalOrder()
    {
        Name newBrand = new Name("EA");
        _brands.Insert(1, newBrand);
        await _repository.Add(newBrand);

        List<Name> result = await _repository.Get();
        
        Assert.Equal(_brands, result);
        
        await _fixture.ReloadDb();
    }

    [Fact]
    public async Task Add_ExistingBrand_ThrowException()
    {
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await _repository.Add(new Name("Apple"));
            await _fixture.ReloadDb();
        });
    }

    [Fact]
    public async Task Delete_ExistingBrand_SeededBrandsWithoutDeletedOne()
    {
        _brands.Remove(new Name("Apple"));
        await _repository.Delete(new Name("Apple"));

        List<Name> result = await _repository.Get();
        
        Assert.Equal(_brands, result);
        
        await _fixture.ReloadDb();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
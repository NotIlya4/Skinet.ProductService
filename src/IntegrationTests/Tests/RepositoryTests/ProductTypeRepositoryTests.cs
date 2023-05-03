using Domain.Primitives;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductTypeRepositoryTests : IDisposable
{
    private readonly IProductTypeRepository _repository;
    private readonly IServiceScope _scope;
    private readonly List<Name> _productTypes;
    private readonly AppFixture _fixture;

    public ProductTypeRepositoryTests(AppFixture fixture)
    {
        _fixture = fixture;
        _productTypes = fixture.ProductTypesList.ProductTypes.ToList();
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IProductTypeRepository>();
    }

    [Fact]
    public async Task Get_SeededEntities_ThatSeededEntities()
    {
        List<Name> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
    }

    [Fact]
    public async Task Add_AddNewProductType_SeededProductTypesWithNewOneInAlphabeticalOrder()
    {
        Name newProductType = new Name("Duck");
        _productTypes.Insert(1, newProductType);
        await _repository.Add(newProductType);

        List<Name> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
        
        await _fixture.ReloadDb();
    }

    [Fact]
    public async Task Add_ExistingProductType_ThrowException()
    {
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await _repository.Add(new Name("Smartphone"));
            await _fixture.ReloadDb();
        });
    }

    [Fact]
    public async Task Delete_ExistingProductType_SeededProductTypesWithoutDeletedOne()
    {
        _productTypes.Remove(new Name("Smartphone"));
        await _repository.Delete(new Name("Smartphone"));

        List<Name> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
        
        await _fixture.ReloadDb();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
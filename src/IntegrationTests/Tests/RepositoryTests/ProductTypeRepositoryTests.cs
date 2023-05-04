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
    private readonly List<ProductType> _productTypes;
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
        List<ProductType> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
    }

    [Fact]
    public async Task Add_AddNewProductType_SeededProductTypesWithNewOneInAlphabeticalOrder()
    {
        var newProductType = new ProductType("Duck");
        _productTypes.Insert(1, newProductType);
        await _repository.Add(newProductType);

        List<ProductType> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
        
        await _fixture.ReloadDb();
    }

    [Fact]
    public async Task Add_ExistingProductType_ThrowException()
    {
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await _repository.Add(new ProductType("Smartphone"));
            await _fixture.ReloadDb();
        });
    }

    [Fact]
    public async Task Delete_ExistingProductType_SeededProductTypesWithoutDeletedOne()
    {
        _productTypes.Remove(new ProductType("Smartphone"));
        await _repository.Delete(new ProductType("Smartphone"));

        List<ProductType> result = await _repository.Get();
        
        Assert.Equal(_productTypes, result);
        
        await _fixture.ReloadDb();
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
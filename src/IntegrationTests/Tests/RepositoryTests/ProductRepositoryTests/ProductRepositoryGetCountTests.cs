using Domain.Primitives;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.ProductRepository;
using IntegrationTests.EntityLists;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests.ProductRepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductRepositoryGetCountTests : IDisposable
{
    private readonly IProductRepository _repository;
    private readonly IServiceScope _scope;
    private readonly BrandsList _brandsList;
    private readonly ProductTypesList _productTypesList;

    public ProductRepositoryGetCountTests(AppFixture fixture)
    {
        _brandsList = fixture.BrandsList;
        _productTypesList = fixture.ProductTypesList;
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task SpecifiedBrand_ProductsCountWithSpecifiedBrand()
    {
        int result = await _repository.GetCount(new ProductFluentFilters(brand: _brandsList.Apple));
        
        Assert.Equal(3, result);
    }
    
    [Fact]
    public async Task SpecifiedBrandAndProductType_ProductsCountWithSpecifiedBrandAndProductType()
    {
        int result = await _repository.GetCount(new ProductFluentFilters(brand: _brandsList.Apple, productType: _productTypesList.Smartphone));
        
        Assert.Equal(2, result);
    }

    [Fact]
    public async Task SpecifiedBrandProductTypeAndSearching_ProductsCountWithFilters()
    {
        int result = await _repository.GetCount(new ProductFluentFilters(
            brand: _brandsList.Apple,
            productType: _productTypesList.Smartphone,
            searching: new Name("Pro")));
        
        Assert.Equal(1, result);
    }
    
    public void Dispose()
    {
        _scope.Dispose();
    }
}
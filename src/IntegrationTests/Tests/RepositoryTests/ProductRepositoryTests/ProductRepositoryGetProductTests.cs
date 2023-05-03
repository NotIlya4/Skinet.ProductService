using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.Repositories.ProductRepository;
using IntegrationTests.EntityLists;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests.ProductRepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductRepositoryGetProductTests : IDisposable
{
    private readonly IServiceScope _scope;
    private readonly IProductRepository _repository;
    private readonly ProductsList _productsList;
    
    public ProductRepositoryGetProductTests(AppFixture fixture)
    {
        _productsList = fixture.ProductsList;
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task GetProductById_ProductWithSpecifiedId()
    {
        Product result = await _repository
            .GetProduct(new ProductStrictFilter(ProductStrictFilterProperty.Id, _productsList.BigMac.Id.ToString()));
        
        Assert.Equal(_productsList.BigMac, result);
    }

    [Fact]
    public async Task GetProductByName_ProductWithSpecifiedName()
    {
        Product result = await _repository
            .GetProduct(new ProductStrictFilter(ProductStrictFilterProperty.Name, _productsList.QuarterPounder.Name.ToString()));
        
        Assert.Equal(_productsList.QuarterPounder, result);
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
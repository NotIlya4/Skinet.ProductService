using Domain.Entities;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService.Views;
using Infrastructure.Repositories.ProductRepository;
using IntegrationTests.EntityLists;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests.ProductRepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductRepositoryDeleteTests : IDisposable
{
    private readonly IProductRepository _repository;
    private readonly IServiceScope _scope;
    private readonly ProductsList _productsList;
    private readonly AppFixture _fixture;

    public ProductRepositoryDeleteTests(AppFixture fixture)
    {
        _fixture = fixture;
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _productsList = fixture.ProductsList;
        _repository = _scope.ServiceProvider.GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task DeleteProductById_DeleteSpecifiedProduct()
    {
        var expect = new List<Product>()
        {
            _productsList.BigMac,
            _productsList.IBurger,
            _productsList.IPhone13ProMax,
            _productsList.QuarterPounder,
        };
        await _repository.Delete(new ProductStrictFilter(ProductStrictFilterProperty.Id, _productsList.IPhone13.Id.ToString()));
        
        List<Product> result = await _repository.GetProducts(new GetProductsRequest());
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
    
    [Fact]
    public async Task DeleteProductByName_DeleteSpecifiedProduct()
    {
        var expect = new List<Product>()
        {
            _productsList.BigMac,
            _productsList.IPhone13,
            _productsList.IPhone13ProMax,
            _productsList.QuarterPounder,
        };
        await _repository.Delete(new ProductStrictFilter(ProductStrictFilterProperty.Name, _productsList.IBurger.Name.Value));
        
        List<Product> result = await _repository.GetProducts(new GetProductsRequest());
        
        Assert.Equal(expect, result);

        await _fixture.ReloadDb();
    }
    
    public void Dispose()
    {
        _scope.Dispose();
    }
}
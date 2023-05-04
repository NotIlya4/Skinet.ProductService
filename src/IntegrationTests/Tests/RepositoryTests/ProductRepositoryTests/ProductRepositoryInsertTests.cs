using Domain.Entities;
using Domain.Primitives;
using Infrastructure.ProductService.Views;
using Infrastructure.Repositories.ProductRepository;
using IntegrationTests.EntityLists;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests.ProductRepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductRepositoryInsertTests : IDisposable
{
    private readonly IProductRepository _repository;
    private readonly IServiceScope _scope;
    private readonly ProductsList _productsList;
    private readonly Product _newProduct;
    private readonly AppFixture _fixture;

    public ProductRepositoryInsertTests(AppFixture fixture)
    {
        _fixture = fixture;
        _productsList = fixture.ProductsList;
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IProductRepository>();
        _newProduct = new Product(
            id: new Guid("4197b443-5d9d-4056-a661-ee6ea312f37e"),
            name: new Name("Samsung Galaxy S21"),
            description: new Description(
                "The Samsung Galaxy S21 is a high-end smartphone with a 6.2-inch display and a triple-lens rear camera system."),
            price: new Price(999.99m),
            pictureUrl: new Uri("https://example.com/product.jpg"),
            productType: fixture.ProductTypesList.Smartphone,
            brand: fixture.BrandsList.Apple);
    }

    [Fact]
    public async Task InsertNewProduct_SeededProductsWithNew()
    {
        var expect = new List<Product>()
        {
            _productsList.BigMac,
            _productsList.IBurger,
            _productsList.IPhone13,
            _productsList.IPhone13ProMax,
            _productsList.QuarterPounder,
            _newProduct
        };
        await _repository.Insert(_newProduct);

        List<Product> products = await _repository.GetProducts(new GetProductsRequest());
        
        Assert.Equal(expect, products);

        await _fixture.ReloadDb();
    }
    
    public void Dispose()
    {
        _scope.Dispose();
    }
}
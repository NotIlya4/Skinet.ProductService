using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.SortingSystem;
using Infrastructure.SortingSystem.Product;
using IntegrationTests.EntityLists;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Tests.RepositoryTests.ProductRepositoryTests;

[Collection(nameof(AppFixture))]
public class ProductRepositoryGetProductsTests : IDisposable
{
    private readonly IProductRepository _repository;
    private readonly IServiceScope _scope;
    private readonly List<Product> _products;
    private readonly ProductsList _productsList;
    private readonly ProductTypesList _productTypesList;
    private readonly BrandsList _brandsList;
    
    public ProductRepositoryGetProductsTests(AppFixture fixture)
    {
        _products = fixture.ProductsList.Products.ToList();
        _brandsList = fixture.BrandsList;
        _productsList = fixture.ProductsList;
        _productTypesList = fixture.ProductTypesList;
        _scope = fixture.WebApplicationFactory.Services.CreateScope();
        _repository = _scope.ServiceProvider.GetRequiredService<IProductRepository>();
    }

    [Fact]
    public async Task SeededProducts_ThatSeededProducts()
    {
        List<Product> result = await _repository.GetProducts(new GetProductsRequest());
        
        Assert.Equal(_products, result);
    }

    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [Theory]
    public async Task ValidOffsetLimit1_FirstProduct(int offset)
    {
        List<Product> expect = _products.Skip(offset).Take(1).ToList();
        
        List<Product> result = await _repository.GetProducts(new GetProductsRequest(new Pagination(offset, 1)));

        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task SpecifyProductType_ProductsWithSpecifiedProductType()
    {
        List<Product> expect = new List<Product>()
        {
            _productsList.IPhone13,
            _productsList.IPhone13ProMax,
        };

        List<Product> result = await _repository
            .GetProducts(new GetProductsRequest(new ProductFluentFilters(productType: _productTypesList.Smartphone)));
        
        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task SpecifyBrand_ProductsWithSpecifiedBrand()
    {
        List<Product> expect = new List<Product>()
        {
            _productsList.IBurger,
            _productsList.IPhone13,
            _productsList.IPhone13ProMax,
        };

        List<Product> result = await _repository
            .GetProducts(new GetProductsRequest(new ProductFluentFilters(brand: _brandsList.Apple)));
        
        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task SpecifySearching_ProductsWithMatchingName()
    {
        List<Product> expect = new List<Product>()
        {
            _productsList.IPhone13,
            _productsList.IPhone13ProMax,
        };
        
        List<Product> result = await _repository
            .GetProducts(new GetProductsRequest(new ProductFluentFilters(searching: new Name("iPhone"))));
        
        Assert.Equal(expect, result);
    }

    [Fact]
    public async Task PriceSorting_SortedProducts()
    {
        List<Product> expect = new List<Product>()
        {
            _productsList.IPhone13ProMax,
            _productsList.IPhone13,
            _productsList.IBurger,
            _productsList.QuarterPounder,
            _productsList.BigMac
        };
        
        List<Product> result = await _repository
            .GetProducts(new GetProductsRequest(new ProductSortingCollection(new ProductSorting(ProductSortingProperty.Price, SortingSide.Desc))));
        
        Assert.Equal(expect, result);
    }

    public void Dispose()
    {
        _scope.Dispose();
    }
}
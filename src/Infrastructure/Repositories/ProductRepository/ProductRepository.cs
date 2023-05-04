using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService.Views;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Exceptions;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Repositories.ProductTypeRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly DataMapper _mapper;
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext, DataMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<Product> GetProduct(ProductStrictFilter filter)
    {
        ProductData productData = await _dbContext.GetProduct(filter);
        return _mapper.MapProduct(productData);
    }

    public async Task<List<Product>> GetProducts(GetProductsRequest getProductsRequest)
    {
        List<ProductData> productDatas = await _dbContext.GetProducts(getProductsRequest);
        return _mapper.MapProduct(productDatas);
    }

    public async Task<int> GetCount(ProductFluentFilters filters)
    {
        return await _dbContext.Products
            .IncludeProductDependencies()
            .ApplyFluentFilters(filters)
            .CountAsync();
    }

    public async Task Insert(Product product)
    {
        try
        {
            await GetProduct(new ProductStrictFilter(ProductStrictFilterProperty.Id, product.Id.ToString()));
            await Update(product);
        }
        catch (EntityNotFoundException)
        {
            await Add(product);
        }
    }

    private async Task Update(Product product)
    {
        ProductData productData = await Map(product);

        _dbContext.Products.Update(productData);
        await _dbContext.SaveChangesAsync();
    }
    
    private async Task Add(Product product)
    {
        ProductData productData = await Map(product);

        _dbContext.Products.Add(productData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductStrictFilter filter)
    {
        ProductData productData = await _dbContext.GetProduct(filter);
        
        SetProductEntry(productData);
        
        _dbContext.Products.Remove(productData);
        await _dbContext.SaveChangesAsync();
    }

    private async Task<ProductData> Map(Product product)
    {
        BrandData brandData = await _dbContext.GetBrand(product.Brand);
        ProductTypeData productTypeData = await _dbContext.GetProductType(product.ProductType);
        
        ProductData productData = _mapper.MapProduct(product, productTypeData, brandData);
        SetProductEntry(productData);

        return productData;
    }

    private void SetProductEntry(ProductData productData)
    {
        _dbContext.SetEntry(productData);
        _dbContext.SetEntry(productData.Brand);
        _dbContext.SetEntry(productData.ProductType);
    }
}
using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.Extensions;
using Infrastructure.Repositories.ProductTypeRepository;
using Infrastructure.SortingSystem;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly DataMapper _mapper;
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext, DataMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<Product> GetProduct(ProductStrictFilter productStrictFilter)
    {
        ProductData productData = await _dbContext.GetProduct(productStrictFilter);
        return _mapper.MapProduct(productData);
    }

    public async Task<List<Product>> GetProducts(GetProductsQuery getProductsQuery)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .IncludeProductDependencies();

        IQueryable<ProductData> sortedQuery = query.ApplySorting(getProductsQuery.SortingCollection.PrimarySorting,
            getProductsQuery.SortingCollection.SecondarySortings.Select(s => (ISorting)s).ToList());

        sortedQuery = ApplyFiltering(sortedQuery, getProductsQuery.FluentFilters);

        List<ProductData> productDatas = await sortedQuery
            .ApplyPagination(getProductsQuery.Pagination)
            .ToListAsync();
        return _mapper.MapProduct(productDatas);
    }

    public async Task<int> GetProductsCountForFilters(ProductFluentFilters fluentFilters)
    {
        IQueryable<ProductData> query = _dbContext
            .Products
            .AsNoTracking()
            .IncludeProductDependencies();

        query = ApplyFiltering(query, fluentFilters);

        return await query.CountAsync();
    }

    private IQueryable<ProductData> ApplyFiltering(IQueryable<ProductData> query, ProductFluentFilters fluentFilters)
    {
        if (fluentFilters.ProductTypeName is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(fluentFilters.ProductTypeName.Value));
        }
        
        if (fluentFilters.BrandName is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(fluentFilters.BrandName.Value));
        }

        if (fluentFilters.Searching is not null)
        {
            query = query.Where(p => p.Name.Contains(fluentFilters.Searching.Value));
        }

        return query;
    }

    public async Task Insert(Product product)
    {
        BrandData brandData = await _dbContext.GetBrand(product.Brand);
        ProductTypeData productTypeData = await _dbContext.GetProductType(product.ProductType);
        
        ProductData productData = _mapper.MapProduct(product, productTypeData, brandData);

        SetProductEntry(productData);

        await _dbContext.Products.AddAsync(productData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductStrictFilter productStrictFilter)
    {
        ProductData productData = await _dbContext.GetProduct(productStrictFilter);
        
        SetProductEntry(productData);
        
        _dbContext.Products.Remove(productData);
        await _dbContext.SaveChangesAsync();
    }

    private void SetProductEntry(ProductData productData)
    {
        _dbContext.SetEntry(productData);
        _dbContext.SetEntry(productData.Brand);
        _dbContext.SetEntry(productData.ProductType);
    }
}
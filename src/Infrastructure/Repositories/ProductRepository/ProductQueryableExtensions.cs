using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.FilteringSystem.Product;
using Infrastructure.ProductService;
using Infrastructure.Repositories.Extensions;
using Infrastructure.SortingSystem.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductRepository;

public static class ProductQueryableExtensions
{
    public static IQueryable<ProductData> IncludeProductDependencies(this IQueryable<ProductData> dbSet)
    {
        return dbSet
            .Include(p => p.Brand)
            .Include(p => p.ProductType);
    }

    public static async Task<ProductData> GetProduct(this AppDbContext dbContext, ProductStrictFilter filter)
    {
        return await dbContext.Products.IncludeProductDependencies().FirstAsyncOrThrow(filter.PropertyName, filter.Value);
    }

    public static async Task EnsureProductInTable(this AppDbContext dbContext, ProductData productData)
    {
        ProductData? dbProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productData.Id);
        if (dbProduct is null)
        {
            ProductTypeData productTypeData =
                await dbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productData.ProductType.Name);
            BrandData brandData = await dbContext.Brands.FirstAsyncOrThrow(b => b.Name == productData.Brand.Name);
            
            var newProductData = new ProductData(
                id: productData.Id,
                name: productData.Name,
                description: productData.Description,
                price: productData.Price,
                pictureUrl: productData.PictureUrl,
                productType: productTypeData,
                brand: brandData);
            
            dbContext.SetEntry(newProductData.ProductType);
            dbContext.SetEntry(newProductData.Brand);
            
            await dbContext.Products.AddAsync(newProductData);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task EnsureProductsInTable(this AppDbContext dbContext, IEnumerable<ProductData> productDatas)
    {
        foreach (var productData in productDatas)
        {
            await dbContext.EnsureProductInTable(productData);
        }
    }

    public static IQueryable<ProductData> ApplySorting(this IQueryable<ProductData> query,
        ProductSortingCollection sortingCollection)
    {
        return query.ApplySorting(sortingCollection.PrimarySorting, sortingCollection.SecondarySortings);
    }

    public static IQueryable<ProductData> ApplyFluentFilters(this IQueryable<ProductData> query,
        ProductFluentFilters filters)
    {
        if (filters.ProductType is not null)
        {
            query = query.Where(p => p.ProductType.Name.Equals(filters.ProductType.Value));
        }
        
        if (filters.Brand is not null)
        {
            query = query.Where(p => p.Brand.Name.Equals(filters.Brand.Value));
        }

        if (filters.Searching is not null)
        {
            query = query.Where(p => p.Name.Contains(filters.Searching.Value));
        }

        return query;
    }

    public static async Task<List<ProductData>> GetProducts(this AppDbContext dbContext, GetProductsRequest request)
    {
        return await dbContext.Products
            .IncludeProductDependencies()
            .ApplySorting(request.SortingCollection)
            .ApplyFluentFilters(request.FluentFilters)
            .ApplyPagination(request.Pagination)
            .ToListAsync();
    }
}
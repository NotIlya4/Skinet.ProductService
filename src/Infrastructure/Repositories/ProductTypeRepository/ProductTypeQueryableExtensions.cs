using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public static class ProductTypeQueryableExtensions
{
    public static async Task<ProductTypeData> GetProductType(this AppDbContext dbContext, Name productType)
    {
        return await dbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productType.Value);
    }

    public static async Task EnsureProductTypeInTable(this AppDbContext dbContext, ProductTypeData productTypeData)
    {
        ProductTypeData? dbProductType = await dbContext.ProductTypes.FirstOrDefaultAsync(p => p.Name == productTypeData.Name);
        if (dbProductType is null)
        {
            ProductTypeData newProductType = new ProductTypeData(productTypeData.Id, productTypeData.Name);
            await dbContext.ProductTypes.AddAsync(newProductType);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task EnsureProductTypesInTable(this AppDbContext dbContext, IEnumerable<ProductTypeData> productTypeDatas)
    {
        foreach (var productTypeData in productTypeDatas)
        {
            await EnsureProductTypeInTable(dbContext, productTypeData);
        }
    }
}
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public static class BrandQueryableExtensions
{
    public static async Task<BrandData> GetBrand(this AppDbContext dbContext, Brand brand)
    {
        return await dbContext.Brands.FirstAsyncOrThrow(b => b.Name == brand.Value);
    }

    public static async Task EnsureBrandInTable(this AppDbContext dbContext, BrandData brandData)
    {
        BrandData? dbBrand = await dbContext.Brands.FirstOrDefaultAsync(b => b.Name == brandData.Name);
        if (dbBrand is null)
        {
            BrandData newBrandData = new BrandData(brandData.Id, brandData.Name);
            await dbContext.Brands.AddAsync(newBrandData);
            await dbContext.SaveChangesAsync();
        }
    }

    public static async Task EnsureBrandsInTable(this AppDbContext dbContext, IEnumerable<BrandData> brandDatas)
    {
        foreach (var brandData in brandDatas)
        {
            await dbContext.EnsureBrandInTable(brandData);
        }
    }
}
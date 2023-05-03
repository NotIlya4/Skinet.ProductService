using Infrastructure.EntityFramework.Models;
using Infrastructure.Misc;
using Infrastructure.Repositories.BrandRepository;
using Infrastructure.Repositories.ProductRepository;
using Infrastructure.Repositories.ProductTypeRepository;

namespace Infrastructure.EntityFramework.DbMigratingAndSeeding;

public class DbSeeder
{
    private readonly IServiceProvider _services;
    private readonly IEnumerable<BrandData> _brandDatas;
    private readonly IEnumerable<ProductTypeData> _productTypeDatas;
    private readonly IEnumerable<ProductData> _productDatas;


    public DbSeeder(IServiceProvider services, IEnumerable<BrandData> brandDatas, IEnumerable<ProductTypeData> productTypeDatas, IEnumerable<ProductData> productDatas)
    {
        _services = services;
        _brandDatas = brandDatas.ToList();
        _productTypeDatas = productTypeDatas.ToList();
        _productDatas = productDatas.ToList();
    }
    
    public async Task Seed()
    {
        await _services.UsingScope<AppDbContext>(async dbContext => { await dbContext.EnsureBrandsInTable(_brandDatas); });
        await _services.UsingScope<AppDbContext>(async dbContext => { await dbContext.EnsureProductTypesInTable(_productTypeDatas); });
        await _services.UsingScope<AppDbContext>(async dbContext => { await dbContext.EnsureProductsInTable(_productDatas); });
    }
}
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly DataMapper _mapper;
    private readonly AppDbContext _dbContext;

    public ProductTypeRepository(AppDbContext dbContext, DataMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<ProductType>> Get()
    {
        List<ProductTypeData> productTypeDatas = await _dbContext.ProductTypes.OrderBy(pt => pt.Name).ToListAsync();
        return _mapper.MapProductType(productTypeDatas);
    }

    public async Task Add(ProductType productType)
    {
        ProductTypeData productTypeData = _mapper.MapProductType(0, productType);
        _dbContext.SetEntry(productTypeData);
        
        await _dbContext.ProductTypes.AddAsync(productTypeData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(ProductType productType)
    {
        ProductTypeData productTypeData = await _dbContext.GetProductType(productType);
        _dbContext.ProductTypes.Remove(productTypeData);
        await _dbContext.SaveChangesAsync();
    }
}
using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ProductTypeRepository;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly DataMapper _mapper;
    private readonly ApplicationDbContext _dbContext;

    public ProductTypeRepository(ApplicationDbContext dbContext, DataMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<Name>> GetProductTypes()
    {
        List<ProductTypeData> productTypeDatas = await _dbContext.ProductTypes.OrderBy(pt => pt.Name).ToListAsync();
        return _mapper.MapProductType(productTypeDatas);
    }

    public async Task Add(Name productType)
    {
        ProductTypeData productTypeData = _mapper.MapProductType(Guid.NewGuid(), productType);
        _dbContext.SetEntry(productTypeData);
        
        await _dbContext.ProductTypes.AddAsync(productTypeData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Name productType)
    {
        ProductTypeData productTypeData = await _dbContext.ProductTypes.FirstAsyncOrThrow(p => p.Name == productType.Value);
        _dbContext.SetEntry(productTypeData);
        
        _dbContext.ProductTypes.Remove(productTypeData);
        await _dbContext.SaveChangesAsync();
    }
}
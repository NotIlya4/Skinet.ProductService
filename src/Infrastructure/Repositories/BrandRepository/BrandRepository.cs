using Domain.Primitives;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Models;
using Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.BrandRepository;

public class BrandRepository : IBrandRepository
{
    private readonly DataMapper _mapper;
    private readonly AppDbContext _dbContext;

    public BrandRepository(AppDbContext dbContext, DataMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<List<Name>> Get()
    {
        List<BrandData> brandDatas = await _dbContext.Brands.OrderBy(b => b.Name).ToListAsync();
        return _mapper.MapBrand(brandDatas);
    }

    public async Task Add(Name brand)
    {
        BrandData brandData = _mapper.MapBrand(0, brand);
        _dbContext.SetEntry(brandData);
        
        await _dbContext.Brands.AddAsync(brandData);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Name brand)
    {
        BrandData brandData = await _dbContext.GetBrand(brand);
        _dbContext.Brands.Remove(brandData);
        await _dbContext.SaveChangesAsync();
    }
}
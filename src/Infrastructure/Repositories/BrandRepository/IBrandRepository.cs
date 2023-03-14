﻿using Domain.Entities;
using Domain.Primitives;
using Infrastructure.FilteringSystem;
using Infrastructure.SortingSystem.Models;

namespace Infrastructure.Repositories.BrandRepository;

public interface IBrandRepository
{
    public Task<Brand> GetBrandByName(NotNullString brandName);
    public Task<Brand> GetBrandById(Guid brandId);
    public Task<List<Brand>> GetBrands(Pagination pagination, ISortingInfoProvider<Brand> sortingInfoProvider);
    public Task Insert(Brand brand);
}
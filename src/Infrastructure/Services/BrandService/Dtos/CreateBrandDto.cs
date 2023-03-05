﻿using Domain.Entities;
using Domain.Primitives;

namespace Infrastructure.Services.BrandService.Dtos;

public record CreateBrandDto
{
    public required NotNullString Name { get; set; }
    public required Uri Website { get; set; }

    public Brand ToDomain(Guid brandId)
    {
        return new Brand(
            id: brandId,
            name: Name,
            website: Website);
    }
}
﻿using Api.SwaggerEnrichers.EntityNotFoundExceptionView;

namespace Api.ProducesAttributes.ExceptionViews;

public class EntityNotFoundExceptionView
{
    [EntityNotFoundTitle]
    public required string Title { get; init; }
    [EntityNotFoundDetail]
    public required string Detail { get; init; }
}
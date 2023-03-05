﻿using Domain.Primitives;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Configurations;

public static class ConvertersProvider
{
    public static ValueConverter<Guid, string> GetGuidConverter()
    {
        return new ValueConverter<Guid, string>(
            guid => guid.ToString(),
            str => Guid.Parse(str));
    }

    public static ValueConverter<NotNullString, string> GetHandsomeStringConverter()
    {
        return new ValueConverter<NotNullString, string>(
            hs => hs.ToString(),
            str => new NotNullString(str));
    }

    public static ValueConverter<Uri, string> GetUriConverter()
    {
        return new ValueConverter<Uri, string>(
            uri => uri.ToString(),
            str => new Uri(str));
    }
}
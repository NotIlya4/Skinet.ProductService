using Domain.Exceptions;

namespace Domain.Primitives;

public record ProductType
{
    public string Value { get; }

    public ProductType(string? value)
    {
        DomainValidationException.EnsureNotEmpty(value, nameof(ProductType));

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
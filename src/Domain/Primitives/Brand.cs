using Domain.Exceptions;

namespace Domain.Primitives;

public record Brand
{
    public string Value { get; }

    public Brand(string value)
    {
        DomainValidationException.EnsureNotEmpty(value, nameof(Name));

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
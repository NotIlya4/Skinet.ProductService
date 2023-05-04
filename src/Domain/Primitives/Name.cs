using Domain.Exceptions;

namespace Domain.Primitives;

public record Name
{
    public string Value { get; }

    public Name(string value)
    {
        DomainValidationException.EnsureNotEmpty(value, nameof(Name));

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
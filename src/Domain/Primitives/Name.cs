using Domain.Exceptions;

namespace Domain.Primitives;

public record Name
{
    public string Value { get; }

    public Name(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new DomainValidationException("Name must have at least 1 char");
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
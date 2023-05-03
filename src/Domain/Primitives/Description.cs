using System.Diagnostics.CodeAnalysis;
using Domain.Exceptions;

namespace Domain.Primitives;

public record Description
{
    public string Value { get; }
    
    public static int DescriptionMinLength => 10;
    public static int DescriptionMaxLength => 500;

    public Description(string? value)
    {
        void ThrowLengthException([NotNull] string? v)
        {
            throw new DomainValidationException($"Description must has characters count between " +
                                                $"{DescriptionMinLength} and {DescriptionMaxLength}");
        }
        
        if (string.IsNullOrWhiteSpace(value))
        {
            ThrowLengthException(value);
        }
        
        if (!(value.Length >= DescriptionMinLength && value.Length <= DescriptionMaxLength))
        {
            ThrowLengthException(value);
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
using Domain.Exceptions;

namespace Domain.Primitives;

public record Description
{
    public string Value { get; }
    
    public static int DescriptionMinLength => 10;
    public static int DescriptionMaxLength => 500;

    public Description(string value)
    {
        DomainValidationException.EnsureNotEmpty(value, nameof(Description));
        
        if (!(value.Length >= DescriptionMinLength && value.Length <= DescriptionMaxLength))
        {
            throw new DomainValidationException($"Description must has characters count between " +
                                                $"{DescriptionMinLength} and {DescriptionMaxLength}");
        }

        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }
}
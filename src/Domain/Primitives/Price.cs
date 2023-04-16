using Domain.Exceptions;

namespace Domain.Primitives;

public record Price
{
    public decimal Value { get; }
    
    public Price(decimal value)
    {
        if (value < 0)
        {
            throw new DomainValidationException("Price must be greater than 0");
        }

        Value = value;
    }
}
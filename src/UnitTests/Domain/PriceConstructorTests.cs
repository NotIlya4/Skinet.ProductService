using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Domain;

public class PriceConstructorTests
{
    [Fact]
    public void NegativeValue_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new Price(-1));
    }

    [Fact]
    public void Zero_CreateInstance()
    {
        var result = new Price(0);
    }

    [Fact]
    public void PositiveValue_CreateInstance()
    {
        var result = new Price(1);
    }
}
using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Domain;

public class ProductTypeConstructorTests
{
    [Fact]
    public void EmptyString_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new ProductType(""));
    }

    [Fact]
    public void NotEmptyString_CreateInstance()
    {
        var result = new ProductType("A");
    }
}
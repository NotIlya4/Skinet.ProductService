using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Domain;

public class BrandConstructorTests
{
    [Fact]
    public void EmptyString_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new Brand(""));
    }

    [Fact]
    public void NotEmptyString_CreateInstance()
    {
        var result = new Brand("A");
    }
}
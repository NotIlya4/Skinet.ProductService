using Domain.Exceptions;
using Domain.Primitives;

namespace UnitTests.Domain;

public class NameConstructorTests
{
    [Fact]
    public void EmptyString_ThrowException()
    {
        Assert.Throws<DomainValidationException>(() => new Name(""));
    }

    [Fact]
    public void NotEmptyString_CreateInstance()
    {
        var result = new Name("A");
    }
}
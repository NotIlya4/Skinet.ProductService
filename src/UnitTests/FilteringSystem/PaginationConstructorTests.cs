using Infrastructure.FilteringSystem;

namespace UnitTests.FilteringSystem;

public class PaginationConstructorTests
{
    [Fact]
    public void PassInvalidOffset_ThrowInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => new Pagination(offset: -1, limit: 1));
    }

    [InlineData(0)]
    [InlineData(51)]
    [Theory]
    public void PassInvalidLimit_ThrowInvalidOperationException(int limit)
    {
        Assert.Throws<InvalidOperationException>(() => new Pagination(offset: 0, limit: limit));
    }
}
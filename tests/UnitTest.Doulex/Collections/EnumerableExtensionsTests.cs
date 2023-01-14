using Doulex;

namespace UnitTest.Doulex.Collections;

public class EnumerableExtensionsTests
{
    [Fact]
    public void IsNullOrEmpty_WithNullEnumerable_ReturnsTrue()
    {
        IEnumerable<int>? enumerable = null;
        var               result     = enumerable.IsNullOrEmpty();
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_WithEmptyEnumerable_ReturnsTrue()
    {
        IEnumerable<int> enumerable = Enumerable.Empty<int>();
        var              result     = enumerable.IsNullOrEmpty();
        Assert.True(result);
    }

    [Fact]
    public void IsNullOrEmpty_WithNonEmptyEnumerable_ReturnsFalse()
    {
        IEnumerable<int> enumerable = Enumerable.Range(1, 10);
        var              result     = enumerable.IsNullOrEmpty();
        Assert.False(result);
    }
}

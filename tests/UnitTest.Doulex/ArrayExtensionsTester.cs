using Doulex;

namespace UnitTest.Doulex;

public class ArrayExtensionsTester
{
    [Fact]
    public void Test_IfNotNull_ShouldReturnSelf()
    {
        var source = new[] {1, 2, 3};
        var result = source.ToNullIfEmpty();
        Assert.Equal(source, result);
    }

    [Fact]
    public void Test_IfNull_ShouldReturnNull()
    {
        int[]? source = Array.Empty<int>();
        var    result = source.ToNullIfEmpty();
        Assert.Null(result);
    }

    [Fact]
    public void Test_IfEmpty_ShouldReturnNull()
    {
        var source = Array.Empty<int>();
        var result = source.ToNullIfEmpty();
        Assert.Null(result);
    }
}

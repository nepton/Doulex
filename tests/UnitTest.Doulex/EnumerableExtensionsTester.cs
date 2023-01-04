namespace Doulex;

public class EnumerableExtensionsTester
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
        IEnumerable<int>? source = null;
        var               result = source.ToNullIfEmpty();
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

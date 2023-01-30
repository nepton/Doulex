using Doulex;

namespace UnitTest.Doulex;

public class FloatExtensionsTests
{
    [Fact]
    public void TestAlmostEqual()
    {
        Assert.True(1.0f.AlmostEqual(1.0f));
        Assert.True(1.0f.AlmostEqual(1.0000001f, 1e-6f));
        Assert.False(1.0f.AlmostEqual(1.0000002f));
        Assert.False(1.0f.AlmostEqual(null));
    }

    [Fact]
    public void TestReplaceIfNaN()
    {
        Assert.Equal(1.0f, 1.0f.ReplaceIfNaN(0.0f));
        Assert.Equal(0.0f, float.NaN.ReplaceIfNaN(0.0f));
    }

    [Fact]
    public void TestClamp()
    {
        Assert.Equal(1.0f,  1.0f.Clamp(0.0f, 2.0f));
        Assert.Equal(0.0f,  (-1.0f).Clamp(0.0f, 2.0f));
        Assert.Equal(-1.0f, -1.0f.Clamp(0.0f, 2.0f));
        Assert.Equal(2.0f,  3.0f.Clamp(0.0f, 2.0f));
    }
}

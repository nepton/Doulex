using Doulex;

namespace UnitTest.Doulex;

public class DecimalExtensionsTests
{
    [Theory]
    [InlineData(3.14, 2.5, 4,    3.14)]
    [InlineData(1.23, 2.5, 4,    2.5)]
    [InlineData(-2.5, -4,  -2.5, -2.5)]
    public void Clamp_ShouldReturnTheClampedValue(decimal source, decimal minimum, decimal maximum, decimal expected)
    {
        var actual = source.Clamp(minimum, maximum);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3.1415,  2, 3.14)]
    [InlineData(1.23456, 3, 1.235)]
    [InlineData(1.99,    0, 2)]
    public void Round_ShouldReturnTheRoundedValue(decimal source, int digits, decimal expected)
    {
        var actual = source.Round(digits);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(3.1415,  2, "-2,2", "3.14")]
    [InlineData(1000,    0, "1,0",  "1k")]
    [InlineData(1000000, 0, "1,2",  "1M")]
    public void ToZippedString_ShouldReturnTheExpectedString(decimal source, int digits, string minFold, string expected)
    {
        var actual = source.ToZippedString(digits, minimumFolds: int.Parse(minFold.Split(',')[0]), maximumFolds: int.Parse(minFold.Split(',')[1]));
        Assert.Equal(expected, actual);
    }
}

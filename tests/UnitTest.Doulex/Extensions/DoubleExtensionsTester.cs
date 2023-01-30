using Doulex;

namespace UnitTest.Doulex;

public class DoubleExtensionsTester
{
    /// <summary>
    /// Test almost equal
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="epsilon"></param>
    /// <param name="expected"></param>
    [Theory]
    [InlineData(1.0,        1.0,        1e-7, true)]
    [InlineData(1.0,        1.0,        0.1,  true)]
    [InlineData(1.0,        1.09,       0.1,  true)]
    [InlineData(1.0,        1.2,        0.1,  false)]
    [InlineData(1.0,        1.2,        0.2,  true)]
    [InlineData(double.NaN, double.NaN, 0.0,  false)]
    [InlineData(double.NaN, double.NaN, 0.1,  false)]
    [InlineData(double.NaN, 1.0,        0.0,  false)]
    [InlineData(double.NaN, 1.0,        0.1,  false)]
    [InlineData(1.0,        double.NaN, 0.0,  false)]
    public void TestAlmostEqual(double a, double b, double epsilon, bool expected)
    {
        Assert.Equal(expected, a.AlmostEqual(b, epsilon));
    }

    /// <summary>
    /// Test almost equal
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="epsilon"></param>
    /// <param name="expected"></param>
    [Theory]
    [InlineData(1.0,        1.0,        1e-7, true)]
    [InlineData(1.0,        1.0,        0.1,  true)]
    [InlineData(1.0,        1.09,       0.1,  true)]
    [InlineData(1.0,        1.2,        0.1,  false)]
    [InlineData(1.0,        1.2,        0.2,  true)]
    [InlineData(double.NaN, double.NaN, 0.0,  false)]
    [InlineData(double.NaN, double.NaN, 0.1,  false)]
    [InlineData(double.NaN, 1.0,        0.0,  false)]
    [InlineData(double.NaN, 1.0,        0.1,  false)]
    [InlineData(1.0,        double.NaN, 0.0,  false)]
    [InlineData(null,       1.0,        0.0,  false)]
    [InlineData(1.0,        null,       0.0,  false)]
    [InlineData(null,       null,       0.0,  true)]
    public void TestNullableAlmostEqual(double? a, double? b, double epsilon, bool expected)
    {
        Assert.Equal(expected, a.AlmostEqual(b, epsilon));
    }
}

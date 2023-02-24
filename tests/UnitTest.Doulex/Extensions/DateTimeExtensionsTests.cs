using Doulex;

namespace UnitTest.Doulex;

public class DateTimeExtensionsTests
{
    [Fact]
    public void TestGetMonthRange()
    {
        // 正常测试
        var date = new DateTime(2019, 1, 6);
        var (start, end) = date.GetMonthRange();

        Assert.Equal(new DateTime(2019, 1, 1),                     start);
        Assert.Equal(new DateTime(2019, 2, 1).AddMilliseconds(-1), end);

        // 边界测试
        date         = new DateTime(2019, 1, 31);
        (start, end) = date.GetMonthRange();

        Assert.Equal(new DateTime(2019, 1, 1),                     start);
        Assert.Equal(new DateTime(2019, 2, 1).AddMilliseconds(-1), end);

        // 闰年测试
        date         = new DateTime(2020, 2, 29);
        (start, end) = date.GetMonthRange();

        Assert.Equal(new DateTime(2020, 2, 1),                     start);
        Assert.Equal(new DateTime(2020, 3, 1).AddMilliseconds(-1), end);
    }

    [Fact]
    public void FirstDayOfMonth_ReturnsCorrectDate()
    {
        // Arrange
        var date = new DateTime(2022, 2, 15);

        // Act
        var result = date.FirstDayOfMonth();

        // Assert
        Assert.Equal(new DateTime(2022, 2, 1), result);
    }

    [Fact]
    public void FirstDayOfYear_ReturnsCorrectDate()
    {
        // Arrange
        var date = new DateTime(2022, 2, 15);

        // Act
        var result = date.FirstDayOfYear();

        // Assert
        Assert.Equal(new DateTime(2022, 1, 1), result);
    }
}

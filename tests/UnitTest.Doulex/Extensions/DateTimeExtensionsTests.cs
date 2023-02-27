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

    [Fact]
    public void AsUniversalTime_Returns_UTC()
    {
        // Arrange
        var localTime = new DateTime(2023,            2, 27, 10, 0, 0, DateTimeKind.Local);
        var expected  = new DateTime(localTime.Ticks, DateTimeKind.Utc);

        // Act
        var actual = localTime.AsUniversalTime();

        // Assert
        Assert.Equal(expected,         actual);
        Assert.Equal(DateTimeKind.Utc, actual.Kind);
    }

    [Fact]
    public void AsLocalTime_Returns_Local_Time()
    {
        // Arrange
        var utcTime  = new DateTime(2023,          2, 27, 10, 0, 0, DateTimeKind.Utc);
        var expected = new DateTime(utcTime.Ticks, DateTimeKind.Local);

        // Act
        var actual = utcTime.AsLocalTime();

        // Assert
        Assert.Equal(expected,           actual);
        Assert.Equal(DateTimeKind.Local, actual.Kind);
    }
}

namespace Doulex.Tests;

/// <summary>
/// 测试 TimeSpanExtensions, 确保返回正确的值
/// </summary>
public class TimeSpanExtensionsTests
{
    [Fact]
    public void Test()
    {
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5);
        Assert.Equal("1 天", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(0, 2, 3, 4, 5);
        Assert.Equal("2 小时", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(0, 0, 3, 4, 5);
        Assert.Equal("3 分钟", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(0, 0, 0, 4, 5);
        Assert.Equal("4 秒", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(0, 0, 0, 0, 5);
        Assert.Equal("5 毫秒", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(0, 0, 0, 0, 0);
        Assert.Equal("0 毫秒", timeSpan.ToSummaryString());

        timeSpan = new TimeSpan(-1, -2, -3, -4, -5);
        Assert.Equal("-1 天", timeSpan.ToSummaryString());
    }
}

using Doulex;

namespace UnitTest.Doulex.Extensions;

public class EnumExtensionsTests
{
    public enum ExampleEnum
    {
        Value1,
        Value2,
        Value3
    }

    [Fact]
    public void ToEnum_WithValidString_ReturnsEnumValue()
    {
        // Arrange
        string validString = "Value1";

        // Act
        var result = validString.ToEnum<ExampleEnum>();

        // Assert
        Assert.Equal(ExampleEnum.Value1, result);
    }

    [Fact]
    public void ToEnum_WithInvalidString_ReturnsNull()
    {
        // Arrange
        string invalidString = "InvalidValue";

        // Act
        var result = invalidString.ToEnum<ExampleEnum>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ToEnum_WithNullString_ReturnsNull()
    {
        // Arrange
        string? nullString = null;

        // Act
        var result = nullString.ToEnum<ExampleEnum>();

        // Assert
        Assert.Null(result);
    }
}

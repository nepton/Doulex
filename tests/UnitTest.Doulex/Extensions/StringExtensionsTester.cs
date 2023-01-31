using Doulex;

namespace UnitTest.Doulex.Extensions;

public class StringExtensionsTester
{
    [Fact]
    public void TrimNull_ShouldRemoveNullCharacter()
    {
        // Arrange
        var input    = "string\0with\0null\0characters";
        var expected = "stringwithnullcharacters";

        // Act
        var result = input.TrimNull();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TrimNull_ShouldReturnSameString_WhenNoNullCharacter()
    {
        // Arrange
        var input    = "string without null characters";
        var expected = "string without null characters";

        // Act
        var result = input.TrimNull();

        // Assert
        Assert.Equal(expected, result);
    }
}

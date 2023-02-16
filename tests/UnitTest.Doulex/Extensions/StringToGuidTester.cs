using Doulex;

namespace UnitTest.Doulex.Extensions;

public class StringToGuidTester
{
    [Fact]
    public void ToGuid_Should_Return_Valid_Guid_For_Non_Empty_String()
    {
        // Arrange
        var input = "12345678-1234-1234-1234-123456789012";

        // Act
        var result = input.ToGuid();

        // Assert
        Assert.IsType<Guid>(result);
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    public void ToGuid_Should_Throw_FormatException_For_Empty_String()
    {
        // Arrange
        var input = "";

        // Act and Assert
        Assert.Throws<FormatException>(() => input.ToGuid());
    }

    [Fact]
    public void ToGuid_Should_Throw_FormatException_For_Invalid_Guid_String()
    {
        // Arrange
        var input = "not a guid";

        // Act and Assert
        Assert.Throws<FormatException>(() => input.ToGuid());
    }
}

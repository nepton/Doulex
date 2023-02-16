using Doulex;

namespace UnitTest.Doulex.Extensions;

/// <summary>
/// Test ToMd5Guid
/// </summary>
public class StringToMd5GuidTester
{
    [Theory]
    [InlineData("test string", "99b58d6f-98de-ab6f-7a21-625b7916589c")]
    [InlineData("A",           "7062c57f-a7e7-a80f-1a59-35b72eacbe29")]
    public void ToHashGuid_Should_Return_Valid_Guid(string input, string expectedString)
    {
        // Arrange
        var expected = Guid.Parse(expectedString);

        // Act
        var result = input.ToHashedGuid();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToHashGuid_Should_Return_Same_Guid_For_Same_Input_And_HashType()
    {
        // Arrange
        var input = "test string";

        // Act
        var result1 = input.ToHashedGuid();
        var result2 = input.ToHashedGuid();

        // Assert
        Assert.Equal(result1, result2);
    }
}

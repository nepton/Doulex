using Doulex;

namespace UnitTest.Doulex.Extensions;

public class StringBase64Tester
{
    [Theory]
    [InlineData("test string",         "dGVzdCBzdHJpbmc=")]
    [InlineData("another test string", "YW5vdGhlciB0ZXN0IHN0cmluZw==")]
    public void ToBase64_Should_Return_Valid_Base64_String(string input, string expected)
    {
        // Act
        var result = input.ToBase64();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("dGVzdCBzdHJpbmc=",             "test string")]
    [InlineData("YW5vdGhlciB0ZXN0IHN0cmluZw==", "another test string")]
    public void FromBase64_Should_Return_Valid_String(string input, string expected)
    {
        // Act
        var result = input.FromBase64();

        // Assert
        Assert.Equal(expected, result);
    }
}

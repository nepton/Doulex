using System.Dynamic;
using Doulex;

namespace UnitTest.Doulex;

public class ObjectExtensionsTests
{
    // Test RemoveNullProperty method
    [Fact]
    public void RemoveNullPropertyTest()
    {
        // arrange
        var expected = new
        {
            Name    = "John",
            Age     = 30,
            Address = (string?) null,
            Married = (bool?) null,
        };

        // act
        var actual = expected.RemoveNullProperty();

        // assert
        Assert.Equal(expected.ToDictionary().Where(x => x.Value != null), actual);
        Assert.IsType<ExpandoObject>(actual);

        var expando = (IDictionary<string, object>) actual;
        Assert.False(expando.ContainsKey("Address"));
        Assert.False(expando.ContainsKey("Married"));
    }
}

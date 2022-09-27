using Doulex.Toolkit.Collections;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Doulex.Toolkit.Tests.Collections;

/// <summary>
/// This class is used to test class EquatableHashSet. 
/// </summary>
public class EquatableHashSetTests
{
    /// <summary>
    /// Tests the Add method.
    /// </summary>
    [Fact]
    public void TestEqual()
    {
        var set  = new EquatableHashSet<TestObject>();
        var set2 = new EquatableHashSet<TestObject>();

        for (int i = 0; i < 10; i++)
        {
            set.Add(new TestObject(i + 1,  i.ToString()));
            set2.Add(new TestObject(i + 1, i.ToString()));
        }

        Assert.Equal(10,  set.Count);
        Assert.Equal(10,  set2.Count);
        Assert.Equal(set, set2);
        Assert.True(set.Equals(set2));
        Assert.Equal(set.GetHashCode(), set2.GetHashCode());
    }

    /// <summary>
    /// 创建两个 equatableHashSet 含有相同的元素, 他们 GetHashSet 的值应该一致
    /// </summary>
    [Fact]
    public void TestGetHashCode()
    {
        var set  = new EquatableHashSet<TestObject>();
        var set2 = new EquatableHashSet<TestObject>();

        for (int i = 0; i < 10; i++)
        {
            set.Add(new TestObject(i + 1,  i.ToString()));
            set2.Add(new TestObject(i + 1, i.ToString()));
        }

        Assert.Equal(set.GetHashCode(), set2.GetHashCode());
    }

    /// <summary>
    /// 测试带参数的构造函数, 传入的参数可以正确保存
    /// </summary>
    [Fact]
    public void TestParametersCtor()
    {
        var set = new EquatableHashSet<TestObject>(new TestObject(1, "1"), new TestObject(2, "2"));
        Assert.Equal(2, set.Count);
    }

    /// <summary>
    /// 测试带参数的构造函数, 传入的参数可以正确保存
    /// </summary>
    [Fact]
    public void TestParametersCtor2()
    {
        var set  = new EquatableHashSet<TestObject>(new TestObject(1, "1"), new TestObject(2, "2"));
        var set2 = new EquatableHashSet<TestObject>(set);

        Assert.Equal(2, set2.Count);
        Assert.True(set.Equals(set2));
        Assert.True(set.Equals(set2));
        // ReSharper disable once SuspiciousTypeConversion.Global
        Assert.False(set.Equals("Hello World"));
    }

    record TestObject(int Int, string String);
}

using Doulex.Toolkit.Types;

// ReSharper disable UnusedTypeParameter

namespace Doulex.Toolkit.Tests.Generic;

public class GenericTypeExtensionsTests
{
    [Fact]
    public void GetGenericTypeNameFromTypeTest()
    {
        Assert.Equal("TestClass",                      typeof(TestClass).GetGenericTypeName());
        Assert.Equal("TestGenericClass<Int32>",        typeof(TestGenericClass<int>).GetGenericTypeName());
        Assert.Equal("TestGenericClass<Int32,String>", typeof(TestGenericClass<int, string>).GetGenericTypeName());

        Assert.Equal("TestRecord",                      typeof(TestRecord).GetGenericTypeName());
        Assert.Equal("TestGenericRecord<Int32>",        typeof(TestGenericRecord<int>).GetGenericTypeName());
        Assert.Equal("TestGenericRecord<Int32,String>", typeof(TestGenericRecord<int, string>).GetGenericTypeName());

        Assert.Equal("TestStruct",                      typeof(TestStruct).GetGenericTypeName());
        Assert.Equal("TestGenericStruct<Int32>",        typeof(TestGenericStruct<int>).GetGenericTypeName());
        Assert.Equal("TestGenericStruct<Int32,String>", typeof(TestGenericStruct<int, string>).GetGenericTypeName());
    }

    [Fact]
    public void GetGenericTypeNameFromObjectTest()
    {
        Assert.Equal("TestClass",                      new TestClass().GetGenericTypeName());
        Assert.Equal("TestGenericClass<Int32>",        new TestGenericClass<int>().GetGenericTypeName());
        Assert.Equal("TestGenericClass<Int32,String>", new TestGenericClass<int, string>().GetGenericTypeName());

        Assert.Equal("TestRecord",                      new TestRecord().GetGenericTypeName());
        Assert.Equal("TestGenericRecord<Int32>",        new TestGenericRecord<int>().GetGenericTypeName());
        Assert.Equal("TestGenericRecord<Int32,String>", new TestGenericRecord<int, string>().GetGenericTypeName());

        Assert.Equal("TestStruct",                      new TestStruct().GetGenericTypeName());
        Assert.Equal("TestGenericStruct<Int32>",        new TestGenericStruct<int>().GetGenericTypeName());
        Assert.Equal("TestGenericStruct<Int32,String>", new TestGenericStruct<int, string>().GetGenericTypeName());
    }

    public class TestClass
    {
    }

    public class TestGenericClass<T>
    {
    }

    public class TestGenericClass<T, T2>
    {
    }

    public record TestRecord;

    public record TestGenericRecord<T>;

    public record TestGenericRecord<T, T2>;

    public struct TestStruct
    {
    }

    public struct TestGenericStruct<T>
    {
    }

    public struct TestGenericStruct<T, T2>
    {
    }
}

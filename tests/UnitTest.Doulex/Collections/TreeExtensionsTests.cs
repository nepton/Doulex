using Doulex.Collections;
using FluentAssertions;

namespace UnitTest.Doulex.Collections;

public class TreeExtensionsTests
{
    // 测试 TreeExtensions.ToTree 方法
    [Fact]
    public void ToTree_WhenCalled_ReturnsTree()
    {
        // Arrange
        var root    = new Node { Id = Guid.NewGuid(), ParentId = default };
        var child1  = new Node { Id = Guid.NewGuid(), ParentId = root.Id };
        var child2  = new Node { Id = Guid.NewGuid(), ParentId = root.Id };
        var child3  = new Node { Id = Guid.NewGuid(), ParentId = child1.Id };
        var child4  = new Node { Id = Guid.NewGuid(), ParentId = child1.Id };
        var child5  = new Node { Id = Guid.NewGuid(), ParentId = child2.Id };
        var child6  = new Node { Id = Guid.NewGuid(), ParentId = child2.Id };
        var child7  = new Node { Id = Guid.NewGuid(), ParentId = child3.Id };
        var child8  = new Node { Id = Guid.NewGuid(), ParentId = child3.Id };
        var child9  = new Node { Id = Guid.NewGuid(), ParentId = child4.Id };
        var child10 = new Node { Id = Guid.NewGuid(), ParentId = child4.Id };

        var nodes = new List<Node>
        {
            root,
            child1,
            child2,
            child3,
            child4,
            child5,
            child6,
            child7,
            child8,
            child9,
            child10
        };

        // Act
        var actual = nodes.ToTree(
            array => array.FirstOrDefault(x => x.ParentId == default),
            n => n.Id,
            n => n.ParentId,
            (n, c) => n.Children = c.ToArray());

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(2, root.Children.Length);
        Assert.Equal(2, child1.Children.Length);
        Assert.Equal(2, child2.Children.Length);
        Assert.Equal(2, child3.Children.Length);
        Assert.Equal(2, child4.Children.Length);

        var actualList = actual.Flatten(x => x.Children);
        actualList.Should().BeEquivalentTo(nodes);
    }
}

public class Node
{
    public Guid   Id       { get; set; }
    public Guid   ParentId { get; set; }
    public Node[] Children { get; set; } = [];
}

using Doulex;

namespace UnitTest.Doulex;

public class DisposeTrackingTests
{
    // Test synced disposable
    [Fact]
    public void TestSyncedDisposable()
    {
        int       actual     = 0;
        using var disposable = new DisposeTracking<int>(10, () => actual += 1);
        Assert.False(disposable.IsDisposed);
        disposable.Dispose();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
    }

    // Test async disposable
    [Fact]
    public async Task TestAsyncDisposable()
    {
        int             actual     = 0;
        await using var disposable = new DisposeTracking<int>(10, () => actual += 1);
        Assert.False(disposable.IsDisposed);
        await disposable.DisposeAsync();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
    }

    // Test dispose more than once
    [Fact]
    public async Task TestDisposeMoreThanOnce()
    {
        int             actual     = 0;
        await using var disposable = new DisposeTracking<int>(10, () => actual += 1);
        Assert.False(disposable.IsDisposed);
        await disposable.DisposeAsync();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
        await disposable.DisposeAsync();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
    }

    // Test dispose more than once with sync
    [Fact]
    public void TestDisposeMoreThanOnceWithSync()
    {
        int       actual     = 0;
        using var disposable = new DisposeTracking<int>(10, () => actual += 1);
        Assert.False(disposable.IsDisposed);
        disposable.Dispose();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
        disposable.Dispose();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
    }

    // Test dispose in sub function
    [Fact]
    public async Task TestDisposeInAsyncSubFunction()
    {
        var disposeTestClass = new DisposeTestClass();
        await AsyncFunction(disposeTestClass);
        Assert.Equal(1, disposeTestClass.Value);
    }

    // Test dispose in synced sub function
    [Fact]
    public void TestDisposeInSyncSubFunction()
    {
        var disposeTestClass = new DisposeTestClass();
        SyncFunction(disposeTestClass);
        Assert.Equal(1, disposeTestClass.Value);
    }

    // Test dispose with async callback
    [Fact]
    public async Task TestDisposeWithAsyncCallback()
    {
        int             actual     = 0;
        await using var disposable = new DisposeTracking<int>(10, async () => await Task.Run(() => actual += 1));
        Assert.False(disposable.IsDisposed);
        await disposable.DisposeAsync();
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, actual);
    }

    // Test dispose with async function call
    [Fact]
    public async Task TestDisposeWithAsyncFunctionCall()
    {
        // arrange
        var             tester     = new DisposeTestClass();
        await using var disposable = new DisposeTracking<int>(10, () => tester.IncreaseValueAsync());
        Assert.False(disposable.IsDisposed);

        // act
        await disposable.DisposeAsync();

        // assert
        Assert.True(disposable.IsDisposed);
        Assert.Equal(1, tester.Value);
    }

    private async Task AsyncFunction(DisposeTestClass c)
    {
        await using var disposable = new DisposeTracking<DisposeTestClass>(c, () => c.Value += 1);
    }

    private void SyncFunction(DisposeTestClass c)
    {
        using var disposable = new DisposeTracking<DisposeTestClass>(c, () => c.Value += 1);
    }

    public class DisposeTestClass
    {
        public int Value { get; set; }

        public async Task IncreaseValueAsync()
        {
            await Task.Delay(1000);
            Value += 1;
        }
    }
}

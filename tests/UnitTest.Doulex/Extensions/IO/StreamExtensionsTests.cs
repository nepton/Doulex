using Doulex;

namespace UnitTest.Doulex.Extensions.IO
{
    public class StreamExtensionsTests
    {
        [Fact]
        public void ReadAllBytes_ThrowsException_WhenStreamIsNull()
        {
            Stream? stream = null;

            Assert.Throws<ArgumentNullException>(() => stream!.ReadAllBytes());
        }

        [Fact]
        public void ReadAllBytes_ThrowsException_WhenStreamIsNotReadable()
        {
            using var stream = new MemoryStream();
            stream.Close();

            Assert.Throws<ArgumentException>(() => stream.ReadAllBytes());
        }

        [Fact]
        public void ReadAllBytes_ReturnsEmptyArray_WhenStreamIsEmpty()
        {
            using var stream = new MemoryStream();

            var result = stream.ReadAllBytes();

            Assert.Equal(Array.Empty<byte>(), result);
        }

        [Fact]
        public void ReadAllBytes_ReturnsArrayOfBytes_WhenStreamIsNotEmpty()
        {
            using var stream = new MemoryStream(new byte[] {1, 2, 3, 4});

            var result = stream.ReadAllBytes();

            Assert.Equal(new byte[] {1, 2, 3, 4}, result);
        }

        [Fact]
        public async Task ReadAllBytesAsync_ThrowsException_WhenStreamIsNull()
        {
            Stream? stream = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => stream!.ReadAllBytesAsync());
        }

        [Fact]
        public async Task ReadAllBytesAsync_ThrowsException_WhenStreamIsNotReadable()
        {
            using var stream = new MemoryStream();
            stream.Close();

            await Assert.ThrowsAsync<ArgumentException>(() => stream.ReadAllBytesAsync());
        }

        [Fact]
        public async Task ReadAllBytesAsync_ReturnsEmptyArray_WhenStreamIsEmpty()
        {
            using var stream = new MemoryStream();

            var result = await stream.ReadAllBytesAsync();

            Assert.Equal(Array.Empty<byte>(), result);
        }

        [Fact]
        public async Task ReadAllBytesAsync_ReturnsArrayOfBytes_WhenStreamIsNotEmpty()
        {
            using var stream = new MemoryStream(new byte[] {1, 2, 3, 4});

            var result = await stream.ReadAllBytesAsync();

            Assert.Equal(new byte[] {1, 2, 3, 4}, result);
        }
    }
}

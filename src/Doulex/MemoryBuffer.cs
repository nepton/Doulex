using System.Buffers;
using System.Runtime.CompilerServices;

namespace Doulex
{
    /// <summary>
    /// IMemoryBuffer 比 IMemoryOwner 提供更多的租用内存的信息, 和内存的使用情况
    /// </summary>
    public sealed class MemoryBuffer : IMemoryBuffer
    {
        /// <summary>
        /// Rent a memory buffer from the pool.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IMemoryBuffer Rent(int size)
        {
            return new MemoryBuffer(size);
        }

        private MemoryBuffer(int size)
        {
            Size   = size;
            _array = ArrayPool<byte>.Shared.Rent(size);
        }

        private byte[]? _array;

        /// <summary>
        /// 总共的空间大小
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// 使用的空间
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// 剩余空间
        /// </summary>
        public int Available => Size - Position;

        /// <summary>
        /// 获取总体内存对象
        /// </summary>
        public Memory<byte> Memory => Slice(0, Size);

        /// <summary>
        /// 读取指定范围的切片内存
        /// </summary>
        /// <param name="start">起始位置</param>
        /// <param name="length">要读取的长度</param>
        /// <returns></returns>
        public Memory<byte> Slice(int start, int length)
        {
            var array = _array;
            if (array == null)
                throw new ObjectDisposedException(nameof(MemoryBuffer));

            return new Memory<byte>(array, start, length);
        }

        /// <summary>
        /// 在末尾切所有内存为新的内存
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> SliceAvailable()
        {
            return Slice(Position, Size - Position);
        }

        /// <summary>
        /// 在末尾切一块新的内存
        /// </summary>
        /// <param name="length">申请的空间</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Memory<byte> SliceAvailable(int length)
        {
            return Slice(Position, length);
        }

        /// <summary>
        /// 申请长度
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public Memory<byte> Allocate(int length)
        {
            var memory = Slice(Position, length);
            Position += length;

            return memory;
        }

        /// <summary>
        /// Dispose the memory buffer.
        /// </summary>
        public void Dispose()
        {
            var array = _array;
            if (array == null)
                return;

            _array = null;
            ArrayPool<byte>.Shared.Return(array);
        }
    }
}

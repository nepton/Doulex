namespace Doulex.Toolkit
{
    /// <summary>
    /// IMemoryBuffer 比 IMemoryOwner 提供更多的租用内存的信息, 和内存的使用情况
    /// </summary>
    public interface IMemoryBuffer : IDisposable
    {
        /// <summary>
        /// 获取总体内存对象
        /// </summary>
        Memory<byte> Memory { get; }

        /// <summary>
        /// 总共的空间大小
        /// </summary>
        int Size { get; }

        /// <summary>
        /// 使用到的位置
        /// </summary>
        int Position { get; set; }

        /// <summary>
        /// 剩余可用空间
        /// </summary>
        int Available { get; }

        /// <summary>
        /// 读取指定范围的切片内存
        /// </summary>
        /// <param name="start">读取的切片内存的起始点</param>
        /// <param name="length">要读取的内存的长度</param>
        /// <returns></returns>
        Memory<byte> Slice(int start, int length);

        /// <summary>
        /// 在末尾切所有内存为新的内存
        /// </summary>
        /// <returns></returns>
        Memory<byte> SliceAvailable();

        /// <summary>
        /// 在末尾切一块新的内存
        /// </summary>
        /// <param name="length">申请的空间</param>
        /// <returns></returns>
        Memory<byte> SliceAvailable(int length);

        /// <summary>
        /// 申请长度
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        Memory<byte> Allocate(int length);
    }
}

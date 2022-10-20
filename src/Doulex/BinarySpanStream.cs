#if NETSTANDARD2_1_OR_GREATER

using System.Buffers.Binary;

namespace Doulex
{
    /// <summary>
    /// 二进制操作 Span 类, 每次把值写入目标后, 向后移动 target 至空白区域
    /// </summary>
    public static class BinarySpanStream
    {
        /// <summary>
        /// 把值写入目标, 并向后移动 target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target">保存数据的区域</param>
        /// <returns></returns>
        public static int WriteLittleEndianUInt16(ref Span<byte> target, ushort source)
        {
            const int size = sizeof(ushort);
            BinaryPrimitives.WriteUInt16LittleEndian(target, source);
            target = target[size..];
            return size;
        }

        /// <summary>
        /// 把值写入目标, 并向后移动 target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target">保存数据的区域</param>
        /// <returns></returns>
        public static int WriteLittleEndianUInt32(ref Span<byte> target, uint source)
        {
            const int size = sizeof(uint);
            BinaryPrimitives.WriteUInt32LittleEndian(target, source);
            target = target[size..];
            return size;
        }


        /// <summary>
        /// 把值写入目标, 并向后移动 target
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target">保存数据的区域</param>
        /// <returns></returns>
        public static int WriteLittleEndianInt32(ref Span<byte> target, int source)
        {
            const int size = sizeof(int);
            BinaryPrimitives.WriteInt32LittleEndian(target, source);
            target = target[size..];
            return size;
        }
    }
}
#endif
namespace Doulex.Toolkit;

public static class BooleanExtensions
{
    /// <summary>
    /// 把布尔值转换为整形数, 用来累加成功数量使用
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt32(this bool value)
    {
        return value ? 1 : 0;
    }
}

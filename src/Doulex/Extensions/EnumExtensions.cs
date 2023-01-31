using System.Collections.Concurrent;
using System.Reflection;

namespace Doulex
{
    /// <summary>
    /// The extensions of enum
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 判断指定的枚举值是否在指定的范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static bool In<T>(this T source, params T[] containers) where T : Enum
        {
            return containers.Contains(source);
        }

        /// <summary>
        /// 判断指定的枚举值是否在指定的范围内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static bool NotIn<T>(this T source, params T[] containers) where T : Enum
        {
            return !containers.Contains(source);
        }

        /// <summary>
        /// 保存枚举的文本资源特性头的声明的缓存, 性能可以提高 60 倍 :)
        /// </summary>
        private static readonly ConcurrentDictionary<Type, EnumTextResourceAttribute?> _dictEnumTextResources = new();

        /// <summary>
        /// 根据 EnumTextAttribute 描述, 获取多语言的文本字符串
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Text<TEnum>(this TEnum source) where TEnum : Enum
        {
            var type = source.GetType();

            // Read text from EnumTextAttribute that declare in enum field
            var fieldAttr = type.GetField(source.ToString()).GetCustomAttribute<EnumTextAttribute>();
            if (fieldAttr != null)
            {
                return fieldAttr.Text;
            }

            // Try read text from EnumTextResourceAttribute declare in enum type
            var enumAttr = _dictEnumTextResources.GetOrAdd(type, t => t.GetCustomAttribute<EnumTextResourceAttribute>());
            if (enumAttr != null)
            {
                var text = enumAttr.ResourceManager.GetString($"{type.Name}_{source}");
                if (!string.IsNullOrEmpty(text))
                    return text;
            }

            return source.ToString();
        }
    }
}

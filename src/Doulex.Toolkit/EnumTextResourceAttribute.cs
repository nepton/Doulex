﻿using System.Resources;

namespace Doulex.Toolkit
{
    /// <summary>
    /// 对 Enum 声明的文本资源 Resources.resx 类
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class EnumTextResourceAttribute : Attribute
    {
        /// <summary>
        /// 资源类的类型
        /// </summary>
        public Type TypeOfResource { get; }

        /// <summary>
        /// 资源管理器
        /// </summary>
        private ResourceManager? _resourceManager;

        /// <summary>
        /// TypeOfResource 的资源管理器对象
        /// </summary>
        internal ResourceManager ResourceManager => _resourceManager ??= new(TypeOfResource);

        public EnumTextResourceAttribute(Type typeOfResource)
        {
            TypeOfResource = typeOfResource;
        }
    }
}

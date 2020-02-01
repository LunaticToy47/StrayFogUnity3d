using System;
/// <summary>
/// 静态类常量字段映射为枚举特性
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class StaticClassConstFieldMapForEnumAttribute : AliasTooltipAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_staticType">静态类</param>
    public StaticClassConstFieldMapForEnumAttribute(Type _staticType)
        : this(_staticType,_staticType.Name, _staticType.Name)
    {

    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_staticType">静态类</param>
    /// <param name="_alias">别名</param>
    public StaticClassConstFieldMapForEnumAttribute(Type _staticType, string _alias)
        : this(_staticType, _alias, _alias)
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_staticType">静态类</param>
    /// <param name="_alias">别名</param>
    /// <param name="_tooltip">tooltip</param>
    public StaticClassConstFieldMapForEnumAttribute(Type _staticType, string _alias, string _tooltip)
        : base(_alias, _tooltip)
    {
        staticType = _staticType;
    }
    /// <summary>
    /// 静态类
    /// </summary>
    public Type staticType { get; private set; }
}

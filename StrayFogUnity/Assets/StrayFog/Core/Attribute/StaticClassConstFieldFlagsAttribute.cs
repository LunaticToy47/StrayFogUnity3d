using System;
using UnityEngine;
/// <summary>
/// 静态类常量字段Flags特性
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class StaticClassConstFieldFlagsAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public StaticClassConstFieldFlagsAttribute()
    {
    }
}

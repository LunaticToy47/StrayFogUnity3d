using System;
using UnityEngine;
/// <summary>
/// 只读
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class ReadOnlyAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public ReadOnlyAttribute()
    {
    }
}


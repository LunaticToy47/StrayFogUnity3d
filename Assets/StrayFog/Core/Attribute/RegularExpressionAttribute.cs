using System;
using UnityEngine;
/// <summary>
/// 正则表达式属性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class RegularExpressionAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_pattern">正则表达式</param>
    public RegularExpressionAttribute(string _pattern)
    {
        pattern = _pattern;
    }
    /// <summary>
    /// 正则表达式
    /// </summary>
    public string pattern { get; private set; }
}

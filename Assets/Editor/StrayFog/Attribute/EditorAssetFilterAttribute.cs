using System;
using UnityEngine;

/// <summary>
/// 编辑器资源过滤特性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class EditorAssetFilterAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_filter">过滤字符</param>
    public EditorAssetFilterAttribute(string _filter)
    {
        filter = _filter;
    }

    /// <summary>
    /// 过滤类别
    /// </summary>
    public string filter { get; private set; }
}




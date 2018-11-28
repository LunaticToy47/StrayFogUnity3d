using System;
using UnityEngine;
/// <summary>
/// 别名提示特性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class AliasTooltipAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    public AliasTooltipAttribute(string _alias)
        : this(_alias, string.Empty)
    {

    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_alias">别名</param>
    /// <param name="_tooltip">提示</param>
    public AliasTooltipAttribute(string _alias, string _tooltip)
    //: base(string.IsNullOrEmpty(_tooltip) ? _alias : _tooltip)
    {
        alias = _alias;
        tooltip = _tooltip;
    }

    /// <summary>
    /// 别名
    /// </summary>
    public string alias { get; private set; }
    /// <summary>
    /// Tooltip
    /// </summary>
    public string tooltip { get; private set; }
}


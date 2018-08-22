using System;
using UnityEngine;
/// <summary>
/// Inspector属性显示
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class ReferPropertyDisplayInspectorAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_referPropertyName">参照属性名称</param>
    /// <param name="_referPropertyValue">参照属性值</param>
    public ReferPropertyDisplayInspectorAttribute(string _referPropertyName, params object[] _referPropertyValue)
    {
        referPropertyName = _referPropertyName;
        if (_referPropertyValue != null)
        {
            referPropertyValue = _referPropertyValue;
        }
        else
        {
            referPropertyValue = new object[0];
        }
        indentLevel = 1;
        displayType = enSerializedPropertyDisplayInspectorAttribute.GivenValue;
    }
    /// <summary>
    /// 参照值
    /// </summary>
    public object[] referPropertyValue { get; private set; }
    /// <summary>
    /// 参照属性名称
    /// </summary>
    public string referPropertyName { get; private set; }
    /// <summary>
    /// 缩进
    /// </summary>
    public int indentLevel { get; set; }
    /// <summary>
    /// 显示类型
    /// </summary>
    public enSerializedPropertyDisplayInspectorAttribute displayType { get; set; }
}

/// <summary>
/// Inspector显示属性枚举
/// </summary>
public enum enSerializedPropertyDisplayInspectorAttribute
{
    /// <summary>
    /// 指定值
    /// </summary>
    GivenValue = 0,
    /// <summary>
    /// 非0正整数
    /// </summary>
    NonZeroPositive,
    /// <summary>
    /// 取反
    /// </summary>
    NOT
}


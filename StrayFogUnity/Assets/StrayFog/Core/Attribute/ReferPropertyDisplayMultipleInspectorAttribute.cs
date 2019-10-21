using System;
using UnityEngine;
/// <summary>
/// Inspector属性显示
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
public class ReferPropertyDisplayMultipleInspectorAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_referPropertyName">参照属性名称</param>
    /// <param name="_referPropertyValue">参照属性值</param>
    public ReferPropertyDisplayMultipleInspectorAttribute(string _referPropertyName, params object[] _referPropertyValue)
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
        operatorType = enSerializedPropertyOperatorInspectorAttribute.And;
        referPropertyOperator = enSerializedPropertyOperatorInspectorAttribute.And;
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
    /// <summary>
    /// 运算符
    /// </summary>
    public enSerializedPropertyOperatorInspectorAttribute operatorType { get; set; }
    /// <summary>
    /// 引用属性关系
    /// </summary>
    public enSerializedPropertyOperatorInspectorAttribute referPropertyOperator { get; set; }
}


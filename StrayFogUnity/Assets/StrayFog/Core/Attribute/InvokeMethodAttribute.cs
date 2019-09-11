using System;
using System.Reflection;
using UnityEngine;
/// <summary>
/// 函数调用属性
/// </summary>
[AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
public class InvokeMethodAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_methodName">函数名称</param>
    public InvokeMethodAttribute(string _methodName)
        : this(_methodName, false)
    {

    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_methodName">函数名称</param>
    /// <param name="_isDrawProperty">是否显示属性</param>
    public InvokeMethodAttribute(string _methodName, bool _isDrawProperty)
        : this(_methodName, BindingFlags.NonPublic | BindingFlags.Instance, _isDrawProperty)
    {

    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_methodName">函数名称</param>
    /// <param name="_bindingFlags">BindingFlags</param>
    public InvokeMethodAttribute(string _methodName, BindingFlags _bindingFlags)
        : this(_methodName, _bindingFlags, false)
    {
    }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_methodName">函数名称</param>
    /// <param name="_bindingFlags">BindingFlags</param>
    /// <param name="_isDrawProperty">是否显示属性</param>
    public InvokeMethodAttribute(string _methodName, BindingFlags _bindingFlags, bool _isDrawProperty)
    {
        methodName = _methodName;
        bindingFlags = _bindingFlags;
        isDrawProperty = _isDrawProperty;
    }
    /// <summary>
    /// 方法名称
    /// </summary>
    public string methodName { get; private set; }
    /// <summary>
    /// BindingFlags
    /// </summary>
    public BindingFlags bindingFlags { get; private set; }
    /// <summary>
    /// 是否绘制属性
    /// </summary>
    public bool isDrawProperty { get; private set; }
}

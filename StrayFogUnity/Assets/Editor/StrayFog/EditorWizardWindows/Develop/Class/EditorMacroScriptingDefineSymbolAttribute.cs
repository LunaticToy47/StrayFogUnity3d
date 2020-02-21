using System;
using UnityEngine;
/// <summary>
/// 宏脚本定义符属性
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class EditorMacroScriptingDefineSymbolAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public EditorMacroScriptingDefineSymbolAttribute()
    {
    }
}




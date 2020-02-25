#if UNITY_EDITOR
using System;
using UnityEngine;
/// <summary>
/// 宏脚本定义符属性
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class EditorMacroScriptingDefineSymbolShortcutAttribute : PropertyAttribute
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_shortcutClassify">快捷菜单分类</param>
    public EditorMacroScriptingDefineSymbolShortcutAttribute(enEditorMacroScriptingDefineSymbolShortcutClassify _shortcutClassify)
    {
        shortcutClassify = _shortcutClassify;
    }

    /// <summary>
    /// 快捷菜单分类
    /// </summary>
    public enEditorMacroScriptingDefineSymbolShortcutClassify shortcutClassify { get; private set; }
}
#endif




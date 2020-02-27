#if UNITY_EDITOR
using System;
using System.Reflection;
/// <summary>
/// 宏定义符号子项
/// </summary>
public class EditorMacroDefineSymbol_Item
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_fieldInfo">字段</param>
    public EditorMacroDefineSymbol_Item(FieldInfo _fieldInfo)
    {
        name = _fieldInfo.Name;
        alias = _fieldInfo.GetFirstAttribute<AliasTooltipAttribute>();
        shortcut = _fieldInfo.GetFirstAttribute<EditorMacroScriptingDefineSymbolShortcutAttribute>();
    }

    /// <summary>
    /// 宏名称
    /// </summary>
    public string name { get; private set; }
    /// <summary>
    /// 宏别名
    /// </summary>
    public AliasTooltipAttribute alias { get; private set; }
    /// <summary>
    /// 快捷菜单
    /// </summary>
    public EditorMacroScriptingDefineSymbolShortcutAttribute shortcut { get; private set; }
    /// <summary>
    /// 是否在PlayerSettings脚本宏定义中
    /// </summary>
    public bool isPlayerSettingsChecked { get; private set; }
    /// <summary>
    /// 是否选中
    /// </summary>
    public bool isChecked;

    /// <summary>
    /// 设置是否在PlayerSettings脚本宏定义中
    /// </summary>
    /// <param name="_isChecked">是否选中</param>
    public void SetPlayerSettingsChecked(bool _isChecked)
    {
        isPlayerSettingsChecked = _isChecked;
        isChecked = _isChecked;
    }

    /// <summary>
    /// 是否是指定的快捷菜单
    /// </summary>
    /// <param name="_classify">快捷菜单</param>
    /// <returns>true:是,false:否</returns>
    public bool IsShortcut(enEditorMacroScriptingDefineSymbolShortcutClassify _classify)
    {
        return shortcut != null && ((shortcut.shortcutClassify & _classify) == _classify);
    }
}
#endif
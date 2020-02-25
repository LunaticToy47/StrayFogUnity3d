#if UNITY_EDITOR
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
    /// 是否选中
    /// </summary>
    public bool isChecked;
}
#endif
#if UNITY_EDITOR
/// <summary>
/// 宏定义符号子项
/// </summary>
public class EditorMacroDefineSymbol_Item
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_name">宏名称</param>
    /// <param name="_alias">宏别名</param>
    public EditorMacroDefineSymbol_Item(string _name, AliasTooltipAttribute _alias)
    {
        name = _name;
        alias = _alias;
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
    /// 是否选 中
    /// </summary>
    public bool isChecked;
}
#endif
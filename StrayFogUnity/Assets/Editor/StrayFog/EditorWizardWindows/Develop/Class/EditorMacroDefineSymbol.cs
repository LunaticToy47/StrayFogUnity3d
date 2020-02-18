using System;
using System.Collections.Generic;
/// <summary>
/// 宏定义符号
/// </summary>
public class EditorMacroDefineSymbol
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_type">类型</param>
    public EditorMacroDefineSymbol(Type _type)
    {
        key = _type.GetHashCode();
        type = _type;
        alias = _type.GetFirstAttribute<AliasTooltipAttribute>();
        defineMaping = new Dictionary<string, EditorMacroDefineSymbol_Item>();
        EditorMacroDefineSymbol_Item item = null;
        foreach (KeyValuePair<string, AliasTooltipAttribute> key in _type.NameToAttributeForConstField<AliasTooltipAttribute>())
        {
            item = new EditorMacroDefineSymbol_Item(key.Key, key.Value);
            defineMaping.Add(item.name, item);
        }
    }

    public int key { get; private set; }
    /// <summary>
    /// 类型
    /// </summary>
    public Type type { get; private set; }
    /// <summary>
    /// 别名
    /// </summary>
    public AliasTooltipAttribute alias { get; private set; }
    /// <summary>
    /// 宏定义
    /// </summary>
    public Dictionary<string, EditorMacroDefineSymbol_Item> defineMaping { get; private set; }
    /// <summary>
    /// 检测宏定义
    /// </summary>
    /// <param name="_defines">宏定义</param>
    public void Check(string[] _defines)
    {
        if (_defines != null && _defines.Length > 0)
        {
            foreach (string k in _defines)
            {
                if (defineMaping.ContainsKey(k))
                {
                    defineMaping[k].isChecked = true;
                }
            }
        }
    }
}

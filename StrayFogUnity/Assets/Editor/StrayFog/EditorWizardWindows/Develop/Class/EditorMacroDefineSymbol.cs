#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Reflection;
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
        isRadio = _type.GetFirstAttribute<EditorRadioAttribute>() != null;
        defineMaping = new Dictionary<string, EditorMacroDefineSymbol_Item>();
        EditorMacroDefineSymbol_Item item = null;        
        foreach (FieldInfo key in _type.ToFieldInfosForConstField())
        {
            item = new EditorMacroDefineSymbol_Item(key);
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
    /// 是否单选
    /// </summary>
    public bool isRadio { get; private set; }
    /// <summary>
    /// 宏定义
    /// </summary>
    public Dictionary<string, EditorMacroDefineSymbol_Item> defineMaping { get; private set; }
    /// <summary>
    /// 设置宏定义
    /// </summary>
    /// <param name="_defineNames">宏定义名称组</param>
    public void SetChecked(params string[] _defineNames)
    {
        if (_defineNames != null && _defineNames.Length > 0)
        {
            foreach (string k in _defineNames)
            {
                if (defineMaping.ContainsKey(k))
                {
                    defineMaping[k].isChecked = true;
                }
            }
        }
    }
}
#endif

#if UNITY_EDITOR
using System;
using System.Collections.Generic;
/// <summary>
/// 宏定义符号
/// </summary>
public class EditorUtility_MacroDefineSymbol : AbsEditorSingle
{
    /// <summary>
    /// 加载宏定义符号
    /// </summary>
    /// <returns>核心宏定义符号</returns>
    public Dictionary<int, EditorMacroDefineSymbol> LoadMacroDefineScriptingDefineSymbols()
    {
        Dictionary<int, EditorMacroDefineSymbol> result = new Dictionary<int, EditorMacroDefineSymbol>();
        string[] defines = EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup();
        Type define = typeof(EditorMacroDefineScriptingDefineSymbols);
        Type[] types = define.GetNestedTypes();
        if (types != null && types.Length > 0)
        {
            foreach (Type t in types)
            {
                EditorMacroDefineSymbol symbol = new EditorMacroDefineSymbol(t);
                if (!result.ContainsKey(symbol.key))
                {
                    result.Add(symbol.key, symbol);
                }
                symbol.SetChecked(defines);
            }
        }
        return result;
    }

    /// <summary>
    /// 保存宏定义符号
    /// </summary>
    /// <param name="_symbols">宏定义符号</param>
    public void SaveMacroDefineScriptingDefineSymbols(Dictionary<int, EditorMacroDefineSymbol> _symbols)
    {
        List<string> saveDefines = new List<string>();
        List<string> removeDefines = new List<string>();
        foreach (EditorMacroDefineSymbol key in _symbols.Values)
        {
            foreach (EditorMacroDefineSymbol_Item d in key.defineMaping.Values)
            {
                if (d.isChecked)
                {
                    if (!saveDefines.Contains(d.name))
                    {
                        saveDefines.Add(d.name);
                    }
                }
                else
                {
                    if (!removeDefines.Contains(d.name))
                    {
                        removeDefines.Add(d.name);
                    }
                }
            }
        }
        EditorStrayFogApplication.RemoveScriptingDefineSymbol(removeDefines.ToArray());
        EditorStrayFogApplication.AddScriptingDefineSymbol(saveDefines.ToArray());
    }
}
#endif

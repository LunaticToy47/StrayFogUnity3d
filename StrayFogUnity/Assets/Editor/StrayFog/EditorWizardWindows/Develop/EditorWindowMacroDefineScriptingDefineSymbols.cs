#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 脚本编译宏指令
/// </summary>
public class EditorWindowMacroDefineScriptingDefineSymbols : AbsEditorWindow
{
    /// <summary>
    /// 宏定义符号
    /// </summary>
    class EditorMacroDefineSymbol
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

    /// <summary>
    /// 宏定义符号子项
    /// </summary>
    class EditorMacroDefineSymbol_Item
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

    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

    /// <summary>
    /// 宏符号定义
    /// </summary>
    Dictionary<int, EditorMacroDefineSymbol> mMacroDefineMaping = new Dictionary<int, EditorMacroDefineSymbol>();

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        OnLoadDefine();
    }

    void OnGUI()
    {
        DrawBrower();
        DrawAssetNodes();
    }

    #region DrawBrower
    /// <summary>
    /// DrawBrower
    /// </summary>
    void DrawBrower()
    {
        
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        EditorGUILayout.HelpBox("The System and Develop macro define is setting in EnumMacroDefineScriptingDefineSymbols.cs file.", MessageType.Info);

        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        foreach (KeyValuePair<int, EditorMacroDefineSymbol> macro in mMacroDefineMaping)
        {
            EditorGUILayout.LabelField(string.Format("【{0}】{1}", macro.Value.type.Name, macro.Value.alias.alias));
            foreach (EditorMacroDefineSymbol_Item define in macro.Value.defineMaping.Values)
            {
                EditorGUILayout.BeginHorizontal();
                define.isChecked = EditorGUILayout.ToggleLeft(
                    string.Format("{0}【{1}】", define.name, define.alias.alias), define.isChecked);
                if (GUILayout.Button(string.Format("Copy 【{0}】Define", define.alias.alias)))
                {
                    EditorStrayFogApplication.CopyToClipboard(define.name);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorStrayFogUtility.guiLayout.DrawSeparator();
        }

        if (GUILayout.Button("Save Define"))
        {
            OnSaveDefine();
        }
        EditorGUILayout.EndScrollView();
    }
    #endregion

    #region OnLoadDefine 加载宏定义
    /// <summary>
    /// 加载宏定义
    /// </summary>
    void OnLoadDefine()
    {
        string[] defines = EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup();

        Type define = typeof(StrayFogCoreMacroDefineScriptingDefineSymbols);
        Type[] types = define.GetNestedTypes();
        if (types != null && types.Length > 0)
        {
            foreach (Type t in types)
            {
                EditorMacroDefineSymbol symbol = new EditorMacroDefineSymbol(t);
                if (!mMacroDefineMaping.ContainsKey(symbol.key))
                {
                    mMacroDefineMaping.Add(symbol.key, symbol);
                }
                symbol.Check(defines);
            }
        }
    }
    #endregion

    #region OnSaveDefine 保存宏定义
    /// <summary>
    /// 保存宏定义
    /// </summary>
    void OnSaveDefine()
    {
        List<string> saveDefines = new List<string>();
        List<string> removeDefines = new List<string>();
        foreach(EditorMacroDefineSymbol key in mMacroDefineMaping.Values)
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
        EditorUtility.DisplayDialog("Setting ScriptDefineSymbols", "Setting ScriptDefineSymbols Success.", "OK");
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
    }
    #endregion
}
#endif
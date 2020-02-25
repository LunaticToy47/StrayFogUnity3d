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
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

    /// <summary>
    /// 核心宏定义符号
    /// Key:符号Key
    /// Value:符号
    /// </summary>
    Dictionary<int, EditorMacroDefineSymbol> mCoreMacroDefineScriptingDefineSymbolsMaping = new Dictionary<int, EditorMacroDefineSymbol>();

    /// <summary>
    /// OnFocus
    /// </summary>
    private void OnFocus()
    {
        mCoreMacroDefineScriptingDefineSymbolsMaping = EditorStrayFogUtility.macroDefineSymbol.LoadMacroDefineScriptingDefineSymbols();
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
        EditorGUILayout.HelpBox("The macro define is setting in class=>" + typeof(EditorMacroDefineScriptingDefineSymbols).Name, MessageType.Info);

        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        EditorStrayFogUtility.macroDefineSymbol.EditorGUILayout_DrawMacroDefineSymbol(mCoreMacroDefineScriptingDefineSymbolsMaping);        
        EditorGUILayout.EndScrollView();

        if (GUILayout.Button("Save Define"))
        {
            OnSaveDefine();
        }
        
    }
    #endregion

    #region OnSaveDefine 保存宏定义
    /// <summary>
    /// 保存宏定义
    /// </summary>
    void OnSaveDefine()
    {
        EditorStrayFogUtility.macroDefineSymbol.SaveMacroDefineScriptingDefineSymbols(mCoreMacroDefineScriptingDefineSymbolsMaping);
        EditorUtility.DisplayDialog("Setting ScriptDefineSymbols", "Setting ScriptDefineSymbols Success.", "OK");
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
    }
    #endregion
}
#endif
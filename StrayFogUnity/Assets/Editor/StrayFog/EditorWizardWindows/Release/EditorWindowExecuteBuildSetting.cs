#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成UI窗口映射
/// </summary>
public class EditorWindowExecuteBuildSetting : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

    /// <summary>
    /// 宏定义
    /// </summary>
    Dictionary<int, EditorMacroDefineSymbol> mEditorMacroDefineSymbolMaping = new Dictionary<int, EditorMacroDefineSymbol>();
    
    /// <summary>
    /// OnFocus
    /// </summary>
    private void OnFocus()
    {
        mEditorMacroDefineSymbolMaping = EditorStrayFogUtility.macroDefineSymbol.LoadMacroDefineScriptingDefineSymbols();
    }

    /// <summary>
    /// OnGUI
    /// </summary>
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
        foreach (EditorMacroDefineSymbol key in mEditorMacroDefineSymbolMaping.Values)
        {

        }
        EditorGUILayout.Separator();
    }
    #endregion

    #region DrawAssetNodes 绘制节点
    /// <summary>
    /// 绘制节点
    /// </summary>
    void DrawAssetNodes()
    {

    }
    #endregion
}
#endif

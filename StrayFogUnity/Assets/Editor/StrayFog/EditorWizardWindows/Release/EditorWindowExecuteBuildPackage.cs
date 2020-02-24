#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 执行发布窗口
/// </summary>
public class EditorWindowExecuteBuildPackage : AbsEditorWindow
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
        if (GUILayout.Button("Build Package"))
        {
            OnExecuteBuildPackage();
        }
    }
    #endregion

    #region OnExecuteBuildPackage
    /// <summary>
    /// 执行发包
    /// </summary>
    void OnExecuteBuildPackage()
    {
        if (EditorStrayFogApplication.MenuItemQuickDisplayDialog_OKCancel("Are you sure ExecuteBuildPackage?"))
        {
            EditorStrayFogExecute.ExecuteBuildPackage();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed("ExecuteBuildPackage");
        }
    }
    #endregion
}
#endif

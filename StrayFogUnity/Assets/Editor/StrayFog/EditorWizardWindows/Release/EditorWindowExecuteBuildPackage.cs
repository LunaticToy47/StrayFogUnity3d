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
    /// 快捷菜单滚动视图位置
    /// </summary>
    Vector2 mShortcutMenuScrollViewPosition = Vector2.zero;

    /// <summary>
    /// 宏定义滚动视图位置
    /// </summary>
    Vector2 mMacroDefineSymbolScrollViewPosition = Vector2.zero;

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
        EditorGUILayout.BeginHorizontal();
        //快捷菜单
        mShortcutMenuScrollViewPosition = EditorGUILayout.BeginScrollView(mShortcutMenuScrollViewPosition);
        EditorStrayFogUtility.macroDefineSymbol.EditorGUILayout_DrawMacroDefineSymbolShortcut(mEditorMacroDefineSymbolMaping);
        EditorGUILayout.EndScrollView();

        //宏定义符
        EditorGUILayout.BeginVertical();
        mMacroDefineSymbolScrollViewPosition = EditorGUILayout.BeginScrollView(mMacroDefineSymbolScrollViewPosition);
        EditorStrayFogUtility.macroDefineSymbol.EditorGUILayout_DrawMacroDefineSymbol(mEditorMacroDefineSymbolMaping);
        EditorGUILayout.EndScrollView();
        if (GUILayout.Button("保存已选择的宏定义"))
        {
            EditorStrayFogUtility.macroDefineSymbol.SaveMacroDefineScriptingDefineSymbols(mEditorMacroDefineSymbolMaping);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
        EditorStrayFogUtility.guiLayout.DrawSeparator();
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

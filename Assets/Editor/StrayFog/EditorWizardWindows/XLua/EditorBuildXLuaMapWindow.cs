#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成XLua脚本映射
/// </summary>
public class EditorBuildXLuaMapWindow : AbsEditorWindow
{
    /// <summary>
    /// XLua配置
    /// </summary>
    EditorXLuaMapConfig mConfig;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXLuaMapConfig;
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
        EditorGUILayout.LabelField("XLua Map Config File:");
        mConfig.DrawGUI();
        EditorGUILayout.Separator();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        if (GUILayout.Button("Export XLua Map To XLS"))
        {
            EditorStrayFogExecute.ExportXLuaMapToXLS();
            EditorUtility.DisplayDialog("XLua Map", "ExportXLuaMapToXLS successed.", "OK");
        }
    }
    #endregion
}
#endif

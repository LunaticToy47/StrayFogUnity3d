#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成Asmdef脚本映射
/// </summary>
public class EditorBuildAsmdefMapWindow : AbsEditorWindow
{
    /// <summary>
    /// Asmdef配置
    /// </summary>
    EditorXlsFileConfigForAsmdefMap mConfig;

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXlsFileConfigForAsmdefMap;
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
        EditorGUILayout.LabelField("Asmdef Map Config File:");
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
        if (GUILayout.Button("Export Asmdef Map To XLS"))
        {
            EditorStrayFogExecute.ExecuteAsmdefToXLS();
            EditorUtility.DisplayDialog("Asmdef Map", "ExportAsmdefMapToXLS successed.", "OK");
        }
    }
    #endregion
}
#endif

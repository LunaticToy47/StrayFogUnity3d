#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 生成XLua脚本映射
/// </summary>
public class EditorWindowBuildXLuaMap : AbsEditorWindow
{
    /// <summary>
    /// XLua配置
    /// </summary>
    EditorXlsFileConfigForXLuaMap mConfig;

    /// <summary>
    /// XLua配置
    /// </summary>
    EditorFolderConfigForXLuaMap mFolder;

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setXlsFileConfigForXLuaMap;
        mFolder = EditorStrayFogSavedAssetConfig.setFolderConfigForXLuaMap;
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
        EditorGUILayout.LabelField("XLua Script Folder:");
        mFolder.DrawGUI();
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

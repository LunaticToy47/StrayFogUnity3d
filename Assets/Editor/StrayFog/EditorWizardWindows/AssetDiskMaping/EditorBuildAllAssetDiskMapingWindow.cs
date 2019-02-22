#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置资源AssetDiskMaping窗口
/// </summary>
public class EditorBuildAllAssetDiskMapingWindow : AbsEditorWindow
{
    /// <summary>
    /// 文件映射配置
    /// </summary>
    EditorXlsFileConfigForSetAssetDiskMapingFile mFileMapingConfig;
    /// <summary>
    /// 文件夹映射配置
    /// </summary>
    EditorXlsFileConfigForSetAssetDiskMapingFolder mFolderMapingConfig;
    
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mFileMapingConfig = EditorStrayFogSavedAssetConfig.setAssetDiskMapingFileXlsMapingConfig;
        mFolderMapingConfig = EditorStrayFogSavedAssetConfig.setAssetDiskMapingFolderXlsMapingConfig;
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
        EditorGUILayout.LabelField("AssetDiskMapingFile Config:");
        mFileMapingConfig.DrawGUI();
        EditorGUILayout.LabelField("AssetDiskMapingFolder Config:");
        mFolderMapingConfig.DrawGUI();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Build All AssetDiskMaping"))
        {
            EditorStrayFogExecute.ExecuteBuildAllAssetDiskMaping();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed("Build All AssetDiskMaping");
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
#endif
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
    EditorSetAssetDiskMapingFileXlsMapingConfig mFileMapingConfig;
    /// <summary>
    /// 文件夹映射配置
    /// </summary>
    EditorSetAssetDiskMapingFolderXlsMapingConfig mFolderMapingConfig;
    
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mFileMapingConfig = EditorStrayFogSavedConfigAssetFile.setAssetDiskMapingFileXlsMapingConfig;
        mFolderMapingConfig = EditorStrayFogSavedConfigAssetFile.setAssetDiskMapingFolderXlsMapingConfig;
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
        if (mFileMapingConfig.file != null)
        {
            mFileMapingConfig.file.DrawGUI();
        }
        EditorGUILayout.LabelField("AssetDiskMapingFolder Config:");
        if (mFolderMapingConfig.file != null)
        {
            mFolderMapingConfig.file.DrawGUI();
        }      
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
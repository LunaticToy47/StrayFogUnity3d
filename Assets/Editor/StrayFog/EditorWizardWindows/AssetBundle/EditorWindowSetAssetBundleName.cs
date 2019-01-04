#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置资源AssetBundleName窗口
/// </summary>
public class EditorWindowSetAssetBundleName : AbsEditorWindow
{
    /// <summary>
    /// 配置
    /// </summary>
    EditorSetAssetBundleNameConfig mConfig;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedConfigAssetFile.setAssetBundleName;
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
        if (mConfig.file != null)
        {
            mConfig.file.DrawGUI();
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
        if (GUILayout.Button("Set Name"))
        {
            EditorStrayFogExecute.ExecuteSetAssetBundleName();
            EditorUtility.DisplayDialog("Set AssetBundleName", "set AssetBundle success", "OK");
        }

        if (GUILayout.Button("Clear Name"))
        {
            EditorStrayFogExecute.ExecuteClearAllAssetBundleName();
            EditorUtility.DisplayDialog("Clear AssetBundleName", "clear AssetBundle success", "OK");
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
#endif
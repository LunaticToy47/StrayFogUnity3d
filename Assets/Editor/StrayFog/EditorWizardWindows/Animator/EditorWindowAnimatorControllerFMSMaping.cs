#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置
/// </summary>
public class EditorWindowAnimatorControllerFMSMaping : AbsEditorWindow
{
    /// <summary>
    /// 配置
    /// </summary>
    EditorAnimatorControllerFMSMapingConfig mConfig;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedAssetConfig.setAnimatorControllerFMSMaping;
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
        mConfig.DrawGUI();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Build Animator Controller FMS Maping"))
        {
            EditorStrayFogExecute.ExecuteBuildAnimatorControllerFMSMaping();
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
#endif
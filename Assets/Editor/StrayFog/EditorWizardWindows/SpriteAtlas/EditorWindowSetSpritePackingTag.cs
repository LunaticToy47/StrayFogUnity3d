#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置
/// </summary>
public class EditorWindowSetSpritePackingTag : AbsEditorWindow
{
    /// <summary>
    /// 配置
    /// </summary>
    EditorSetSpritePackingTagConfig mConfig;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mConfig = EditorStrayFogSavedConfigAssetFile.setSpritePackingTag;
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
        if (mConfig.folder != null)
        {
            mConfig.folder.DrawGUI();
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
        if (GUILayout.Button("Set Packing Tag"))
        {
            EditorStrayFogExecute.ExecuteSetSpritePackingTag();
        }
        if (GUILayout.Button("Clear Packing Tag"))
        {
            EditorStrayFogExecute.ExecuteClearSpritePackingTag();
        }
        EditorGUILayout.EndHorizontal();
    }
    #endregion
}
#endif
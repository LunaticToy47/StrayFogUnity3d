#if UNITY_EDITOR
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置工程配置
/// </summary>
public class EditorWindowSettingProjectConfig : AbsEditorWindow
{
    /// <summary>
    /// 可保存资源DrawUI接口
    /// </summary>
    List<IEditorSavedAssetDrawUI> mSavedAssetDrawUIMaping = new List<IEditorSavedAssetDrawUI>();

    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;

    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        mSavedAssetDrawUIMaping.Clear();
        FieldInfo[] fields = typeof(EditorStrayFogSavedAssetConfig).GetFields();
        foreach (FieldInfo f in fields)
        {
            object value = f.GetValue(null);
            if (value is IEditorSavedAssetDrawUI)
            {
                mSavedAssetDrawUIMaping.Add((IEditorSavedAssetDrawUI)value);
            }
        }
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
        mScrollViewPosition = EditorGUILayout.BeginScrollView(mScrollViewPosition);
        if (mSavedAssetDrawUIMaping != null && mSavedAssetDrawUIMaping.Count > 0)
        {
            foreach (IEditorSavedAssetDrawUI d in mSavedAssetDrawUIMaping)
            {
                d.DrawGUI();                               
                GUILayout.HorizontalSlider(0, 0, 0, GUILayout.Height(1));
                EditorGUILayout.Separator();
                EditorGUILayout.Separator();
            }
        }
        EditorGUILayout.EndScrollView();
    }
    #endregion

    #region DrawAssetNodes
    /// <summary>
    /// DrawAssetNodes
    /// </summary>
    private void DrawAssetNodes()
    {
    }
    #endregion
}
#endif
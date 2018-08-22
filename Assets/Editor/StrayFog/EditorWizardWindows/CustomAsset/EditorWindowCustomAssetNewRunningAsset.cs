using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 自定义运行时资源窗口
/// </summary>
public class EditorWindowCustomAssetNewRunningAsset : EditorWindow
{
    /// <summary>
    /// 已存在的资源组
    /// </summary>
    List<EditorEngineAssetConfig> mExistsConfigs = new List<EditorEngineAssetConfig>();
    /// <summary>
    /// 存在滚动视图位置
    /// </summary>
    Vector2 mScrollViewPositionExists = Vector2.zero;
    /// <summary>
    /// 不存在的资源组
    /// </summary>
    List<EditorEngineAssetConfig> mNoExistsConfigs = new List<EditorEngineAssetConfig>();
    /// <summary>
    /// 不存在滚动视图位置
    /// </summary>
    Vector2 mScrollViewPositionNoExists = Vector2.zero;
    /// <summary>
    /// OnFocus
    /// </summary>
    void OnFocus()
    {
        OnLoadConfigs();
    }
    /// <summary>
    /// 加载配置
    /// </summary>
    void OnLoadConfigs()
    {
        mExistsConfigs.Clear();
        mNoExistsConfigs.Clear();
        Type t = EditorStrayFogAssembly.GetType("AbsRunningScriptableObject");
        List<Type> types = EditorStrayFogAssembly.GetExportedTypes(t);
        EditorEngineAssetConfig temp = null;
        if (types != null && types.Count > 0)
        {
            foreach (Type s in types)
            {
                if (!s.Equals(t))
                {
                    temp = new EditorEngineAssetConfig(s.Name,
                    enEditorApplicationFolder.Game_AssetBundles_Assets.GetAttribute<EditorApplicationFolderAttribute>().path,
                    enFileExt.Asset, s.FullName);
                    if (temp.Exists())
                    {
                        mExistsConfigs.Add(temp);
                    }
                    else
                    {
                        mNoExistsConfigs.Add(temp);
                    }

                }
            }
        }
    }
    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        DrawAssets("【Exists】", mExistsConfigs, ref mScrollViewPositionExists);
        DrawAssets("【NoExists】", mNoExistsConfigs, ref mScrollViewPositionNoExists);
        if (mNoExistsConfigs.Count > 0 && GUILayout.Button("Create Assets"))
        {
            foreach (EditorEngineAssetConfig c in mNoExistsConfigs)
            {
                c.CreateAsset();
            }
            EditorUtility.DisplayDialog("Custom Asset ", "Create Asset success!", "OK");
            EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
            OnLoadConfigs();
        }
    }

    /// <summary>
    /// 绘制资源
    /// </summary>
    /// <param name="_title">标题</param>
    /// <param name="_assets">资源</param>
    /// <param name="_scrollViewPosition">滚动视图位置</param>
    void DrawAssets(string _title, List<EditorEngineAssetConfig> _assets, ref Vector2 _scrollViewPosition)
    {
        if (_assets.Count > 0)
        {
            EditorGUILayout.LabelField(_title);
            _scrollViewPosition = EditorGUILayout.BeginScrollView(_scrollViewPosition);
            for (int i = 0; i < _assets.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(
                    string.Format("{0}.{1}",
                    (i + 1).PadLeft(_assets.Count),
                    _assets[i].name
                    ));
                if (_assets[i].Exists() && GUILayout.Button("Browse"))
                {
                    EditorStrayFogApplication.PingObject(_assets[i].fileName);
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
        }
    }
}

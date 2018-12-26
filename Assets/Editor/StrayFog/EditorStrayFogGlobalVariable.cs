﻿#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 全局变量
/// </summary>
public sealed class EditorStrayFogGlobalVariable
{
    #region UIWindow
    /// <summary>
    /// UI窗口视图脚本目录
    /// </summary>
    public static readonly string uiWindowViewScriptFolder = enEditorApplicationFolder.Game_Script_UIWindow.GetAttribute<EditorApplicationFolderAttribute>().path;
    /// <summary>
    /// UI窗口视图脚本
    /// </summary>
    public static readonly EditorTextAssetConfig uiWindowViewScript = new EditorTextAssetConfig("", uiWindowViewScriptFolder, enFileExt.CS, "");
    /// <summary>
    /// UI窗口预置目录
    /// </summary>
    public static readonly string uiWindowPrefabFolder = enEditorApplicationFolder.Game_AssetBundles_UIWindow.GetAttribute<EditorApplicationFolderAttribute>().path;
    /// <summary>
    /// UI窗口预置
    /// </summary>
    public static readonly EditorEngineAssetConfig uiWindowPrefab = new EditorEngineAssetConfig("", uiWindowPrefabFolder, enFileExt.Prefab, typeof(GameObject).FullName);

    /// <summary>
    /// 收集UI窗口设定资源组
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <returns>UI窗口设定资源组</returns>
    public static List<T> CollectUIWindowSettingAssets<T>()
        where T : EditorSelectionUIWindowSetting
    {
        string[] folders = new string[1] { uiWindowPrefabFolder };
        List<T> result = EditorStrayFogUtility.collectAsset.CollectAsset<T>(folders, enEditorAssetFilterClassify.Prefab, false);
        if (result != null && result.Count > 0)
        {
            foreach (T n in result)
            {
                n.Resolve();
                n.Read();
            }

            result.Sort((x, y) =>
            {
                return y.nameWithoutExtension.CompareTo(x.nameWithoutExtension);
            });
            result.Sort((x, y) =>
            {
                return x.assetNode.layer >= y.assetNode.layer ? 1 : -1;
            });
        }
        return result;
    }
    #endregion
}
#endif
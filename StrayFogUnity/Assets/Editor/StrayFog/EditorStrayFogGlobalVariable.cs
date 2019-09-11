#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 全局变量
/// </summary>
public sealed class EditorStrayFogGlobalVariable
{
    #region UIWindow
    /// <summary>
    /// 收集UI窗口设定资源组
    /// </summary>
    /// <typeparam name="T">资源类型</typeparam>
    /// <returns>UI窗口设定资源组</returns>
    public static List<T> CollectUIWindowSettingAssets<T>()
        where T : EditorSelectionUIWindowSetting
    {
        List<T> result = EditorStrayFogUtility.collectAsset.CollectAsset<T>(
            EditorStrayFogSavedAssetConfig.setFolderConfigForUIWindowPrefab.paths, enEditorAssetFilterClassify.Prefab, false);
        if (result != null && result.Count > 0)
        {
            foreach (T n in result)
            {
                n.Resolve();
                n.Read();
            }

            result.Sort((x, y) =>
            {
                return x.nameWithoutExtension.CompareTo(y.nameWithoutExtension);
            });
            result.Sort((x, y) =>
            {
                return x.assetNode.layer >= y.assetNode.layer ? 1 : -1;
            });
        }
        return result;
    }
    #endregion

    #region xLua
    /// <summary>
    /// 获得要打包的XLua文件
    /// </summary>
    /// <typeparam name="T">XLua设定</typeparam>
    /// <returns></returns>
    public static List<T> CollectionXLua<T>()
        where T:EditorSelectionXLuaMapSetting
    {
        List<T> result = new List<T>();
        string[] folders = EditorStrayFogSavedAssetConfig.setFolderConfigForXLuaMap.paths;
        if (folders != null && folders.Length > 0)
        {
            result = EditorStrayFogUtility.collectAsset.CollectAsset<T>(folders, enEditorAssetFilterClassify.TextAsset, false);
        }
        return result;
    }
    #endregion
}
#endif
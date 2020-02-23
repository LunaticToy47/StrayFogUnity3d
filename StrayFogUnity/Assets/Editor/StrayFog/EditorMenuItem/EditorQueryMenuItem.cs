#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Query查询菜单 
/// </summary>
static class EditorQueryMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Query/";
    /// <summary>
    /// Asset菜单
    /// </summary>
    const string mcAssetMenu = "Assets/" + mcMenu;
    /// <summary>
    /// Hierarchy菜单
    /// </summary>
    const string mcHierarchy = "GameObject/" + mcMenu;
    /// <summary>
    /// 菜单优先级
    /// </summary>
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Query;
    #endregion

    #region Look AssetBundleRoot
    const string mcLookAssetBundleRoot = "Look AssetBundleRoot";
    /// <summary>
    /// 查看AssetBundleRoot
    /// </summary>
    [MenuItem(mcMenu + mcLookAssetBundleRoot, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcLookAssetBundleRoot, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcLookAssetBundleRoot, false, mcPriority + 1)]
    static void EditorQueryMenuItem_LookAssetBundleRoot()
    {
        EditorUtility.RevealInFinder(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().editorReleaseAssetBundleRoot);
    }
    #endregion

    #region Look AssetType
    const string mcLookAssetType = "Look AssetType";
    /// <summary>
    /// 查看资源类型
    /// </summary>
    [MenuItem(mcMenu + mcLookAssetType, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcLookAssetType, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcLookAssetType, false, mcPriority + 2)]
    static void EditorQueryMenuItem_LookAssetType()
    {
        if (Selection.activeObject != null)
        {
            Debug.Log(Selection.activeObject.GetType());
        }
        else
        {
            EditorUtility.DisplayDialog("LookAssetType", "Can't selected any object.", "OK");
        }
    }
    #endregion

    #region Find MissingScript Prefab
    const string mcFindMissingScriptPrefab = "Find MissingScript Prefab";    
    /// <summary>
    /// 查看资源类型
    /// </summary>
    [MenuItem(mcMenu + mcFindMissingScriptPrefab, false, mcPriority + 3)]
    [MenuItem(mcAssetMenu + mcFindMissingScriptPrefab, false, mcPriority + 3)]
    [MenuItem(mcHierarchy + mcFindMissingScriptPrefab, false, mcPriority + 3)]
    static void EditorQueryMenuItem_EditorWindowFindMissingScriptPrefab()
    {
        EditorWindowFindMissingScriptPrefab win =
        EditorWindow.GetWindow<EditorWindowFindMissingScriptPrefab>(mcFindMissingScriptPrefab);
        win.Show();
    }
    #endregion

    #region Look Project Setting
    const string mcLookProjectSetting = "Look Project Setting";
    /// <summary>
    /// 查看工程设定
    /// </summary>
    [MenuItem(mcMenu + mcLookProjectSetting, false, mcPriority + 4)]
    [MenuItem(mcAssetMenu + mcLookProjectSetting, false, mcPriority + 4)]
    [MenuItem(mcHierarchy + mcLookProjectSetting, false, mcPriority + 4)]
    static void EditorQueryMenuItem_EditorWindowLookProjectSetting()
    {
        EditorStrayFogApplication.PingObject(enEditorApplicationFolder.Project_Resources.GetAttribute<EditorApplicationFolderAttribute>().path);
    }
    #endregion
}
#endif
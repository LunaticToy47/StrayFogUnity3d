#if UNITY_EDITOR
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
        EditorUtility.RevealInFinder(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
    }
    #endregion

    #region Look AssetType
    const string mcLookAssetType = "Look AssetType";
    /// <summary>
    /// 查看资源类型
    /// </summary>
    [MenuItem(mcMenu + mcLookAssetType, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcLookAssetType, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcLookAssetType, false, mcPriority + 1)]
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
}
#endif
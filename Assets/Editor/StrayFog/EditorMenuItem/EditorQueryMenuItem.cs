#if UNITY_EDITOR
using UnityEditor;
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
    static void EditorDevelopMenuItem_LookAssetBundleRootWindow()
    {
        EditorUtility.RevealInFinder(StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().assetBundleRoot);
    }
    #endregion
}
#endif
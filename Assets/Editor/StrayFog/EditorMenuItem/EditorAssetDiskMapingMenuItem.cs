#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// 资源磁盘映射 
/// </summary>
static class EditorAssetDiskMapingMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/AssetDiskMaping/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.AssetDiskMaping;
    #endregion

    #region Build All Asset Disk Maping
    const string mcBuildAllAssetDiskMaping = "Build All Asset Disk Maping";
    /// <summary>
    /// 生成所有资源磁盘映射
    /// </summary>
    [MenuItem(mcMenu + mcBuildAllAssetDiskMaping, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildAllAssetDiskMaping, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildAllAssetDiskMaping, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_BuildAllAssetDiskMapingWindow()
    {
        EditorStrayFogExecute.ExecuteBuildAllAssetDiskMaping();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildAllAssetDiskMaping);
    }
    #endregion
}
#endif
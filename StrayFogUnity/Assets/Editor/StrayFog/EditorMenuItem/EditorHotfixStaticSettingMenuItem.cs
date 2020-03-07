#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// HotfixStaticSetting菜单 
/// </summary>
static class EditorHotfixStaticSettingMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/HotfixStaticSetting/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.HotfixStaticSetting;
    #endregion

    #region Build Hotfix Static Setting
    const string mcBuildHotfixStaticSetting = "Build Hotfix Static Setting";
    /// <summary>
    /// 生成曲线
    /// </summary>
    [MenuItem(mcMenu + mcBuildHotfixStaticSetting, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildHotfixStaticSetting, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildHotfixStaticSetting, false, mcPriority + 1)]
    static void EditorAnimCurveMenuItem_EditorWindowExecuteBuildHotfixStaticSetting()
    {
        EditorStrayFogExecute.ExecuteBuildHotfixStaticSetting();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildHotfixStaticSetting);
    }
    #endregion
}
#endif

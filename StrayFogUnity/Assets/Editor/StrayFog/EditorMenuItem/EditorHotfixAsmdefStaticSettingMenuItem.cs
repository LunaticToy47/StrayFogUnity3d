#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// HotfixAsmdefStaticSetting菜单 
/// </summary>
static class EditorHotfixAsmdefStaticSettingMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/HotfixAsmdefStaticSetting/";
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

    #region Look Hotfix Asmdef Static Setting
    const string mcLookHotfixAsmdefStaticSetting = "Look Hotfix Asmdef Static Setting";
    /// <summary>
    /// 查看HotfixAsmdef静态设定
    /// </summary>
    [MenuItem(mcMenu + mcLookHotfixAsmdefStaticSetting, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcLookHotfixAsmdefStaticSetting, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcLookHotfixAsmdefStaticSetting, false, mcPriority + 1)]
    [MenuItem(EditorQueryMenuItem.mcMenu + mcLookHotfixAsmdefStaticSetting, false, EditorQueryMenuItem.mcPriority + 5)]
    [MenuItem(EditorQueryMenuItem.mcAssetMenu + mcLookHotfixAsmdefStaticSetting, false, EditorQueryMenuItem.mcPriority + 5)]
    [MenuItem(EditorQueryMenuItem.mcHierarchy + mcLookHotfixAsmdefStaticSetting, false, EditorQueryMenuItem.mcPriority + 5)]
    static void EditorAnimCurveMenuItem_EditorWindowExecuteLookBuildHotfixAsmdefStaticSetting()
    {
        EditorEngineAssetConfig cfg = EditorStrayFogExecute.ExecuteLookBuildHotfixAsmdefStaticSetting();
        EditorStrayFogApplication.PingObject(cfg.engineAsset);
    }
    #endregion

    #region Build Hotfix Asmdef Static Setting
    const string mcBuildHotfixAsmdefStaticSetting = "Build Hotfix Asmdef Static Setting";
    /// <summary>
    /// 执行生成HotfixAsmdef静态设定
    /// </summary>
    [MenuItem(mcMenu + mcBuildHotfixAsmdefStaticSetting, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcBuildHotfixAsmdefStaticSetting, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcBuildHotfixAsmdefStaticSetting, false, mcPriority + 2)]    
    static void EditorAnimCurveMenuItem_EditorWindowExecuteBuildHotfixAsmdefStaticSetting()
    {
        EditorStrayFogExecute.ExecuteBuildHotfixAsmdefStaticSetting();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildHotfixAsmdefStaticSetting);
    }
    #endregion
}
#endif

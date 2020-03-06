#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 工程菜单
/// </summary>
static class EditorProjectMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Project/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Project;
    #endregion

    #region Build Project Assets
    const string mcBuildProjectAssets = "Build Project Assets";
    /// <summary>
    /// 创建工程资源设定
    /// </summary>
    [MenuItem(mcMenu + mcBuildProjectAssets, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildProjectAssets, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildProjectAssets, false, mcPriority + 1)]
    static void EditorProjectMenuItem_ExecuteBuildProjectAssets()
    {
        EditorStrayFogExecute.ExecuteBuildProjectAssets<StrayFogRunningApplication>();
        EditorStrayFogExecute.ExecuteBuildProjectAssets<StrayFogSetting>();
        EditorStrayFogExecute.ExecuteHotfixAsmdefSetting();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildProjectAssets);
    }
    #endregion

    #region Setting Project Config
    const string mcSettingProjectConfig = "Setting Project Config";
    /// <summary>
    /// 设置工程配置
    /// </summary>
    [MenuItem(mcMenu + mcSettingProjectConfig, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcSettingProjectConfig, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcSettingProjectConfig, false, mcPriority + 2)]
    static void EditorProjectMenuItem_EditorWindowSettingProjectConfig()
    {
        EditorWindowSettingProjectConfig win =
              EditorWindow.GetWindow<EditorWindowSettingProjectConfig>(mcSettingProjectConfig);
        win.Show();
    }
    #endregion
}
#endif

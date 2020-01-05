#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// Asmdef菜单 
/// </summary>
static class EditorAsmdefMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Asmdef/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Asmdef;
    #endregion

    #region Look Package Asmdef
    const string mcLookPackageAsmdef = "Look Package Asmdef";
    /// <summary>
    /// 查看可打包的Asmdef
    /// </summary>
    [MenuItem(mcMenu + mcLookPackageAsmdef, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcLookPackageAsmdef, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcLookPackageAsmdef, false, mcPriority + 1)]
    static void EditorAsmdefMenuItem_EditorWindowExecuteLookPackageAsmdef()
    {
        EditorStrayFogExecute.ExecuteLookPackageAsmdef();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcLookPackageAsmdef);
    }
    #endregion

    #region Build Asmdef Map
    const string mcBuildAsmdefMap = "Build Asmdef Map";
    /// <summary>
    /// 生成Asmdef到XLS表
    /// </summary>
    [MenuItem(mcMenu + mcBuildAsmdefMap, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildAsmdefMap, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildAsmdefMap, false, mcPriority + 1)]
    static void EditorAsmdefMenuItem_EditorWindowBuildAsmdefMap()
    {
        EditorWindowBuildAsmdefMap win =
               EditorWindow.GetWindow<EditorWindowBuildAsmdefMap>(mcBuildAsmdefMap);
        win.Show();
    }
    #endregion
}
#endif

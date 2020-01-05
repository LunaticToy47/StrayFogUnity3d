#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 发布菜单 
/// </summary>
static class EditorReleaseMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Release/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Release;
    #endregion

    #region Build Package
    const string mcBuildPackage = "Build Package";
    /// <summary>
    /// 发布
    /// </summary>
    [MenuItem(mcMenu + mcBuildPackage, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildPackage, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildPackage, false, mcPriority + 1)]
    static void EditorReleaseMenuItem_ExecuteBuildPackage()
    {
        if (EditorStrayFogApplication.MenuItemQuickDisplayDialog_OKCancel("Are you sure ExecuteBuildPackage?"))
        {
            EditorStrayFogExecute.ExecuteBuildPackage();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildPackage);
        }        
    }
    #endregion

    #region Build Bat To Package
    const string mcBuildBatToPackage = "Build Bat To Package";
    /// <summary>
    /// 资源包删除未使用资源批处理
    /// </summary>
    [MenuItem(mcMenu + mcBuildBatToPackage, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcBuildBatToPackage, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcBuildBatToPackage, false, mcPriority + 2)]
    static void EditorReleaseMenuItem_ExecuteBuildBatToPackage()
    {
        EditorStrayFogExecute.ExecuteBuildBatToPackage();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildBatToPackage);
    }
    #endregion

    #region Build Dll To Package
    const string mcBuildDllToPackage = "Build Dll To Package";
    /// <summary>
    /// 生成dll到资源包
    /// </summary>
    [MenuItem(mcMenu + mcBuildDllToPackage, false, mcPriority + 3)]
    [MenuItem(mcAssetMenu + mcBuildDllToPackage, false, mcPriority + 3)]
    [MenuItem(mcHierarchy + mcBuildDllToPackage, false, mcPriority + 3)]
    static void EditorReleaseMenuItem_ExecuteBuildDllToPackage()
    {
        EditorStrayFogExecute.ExecuteBuildDllToPackage();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildDllToPackage);
    }
    #endregion

    #region Build Asmdef To Package
    const string mcBuildAsmdefToPackage = "Build Asmdef To Package";
    /// <summary>
    /// 生成Asmdef到资源包
    /// </summary>
    [MenuItem(mcMenu + mcBuildAsmdefToPackage, false, mcPriority + 3)]
    [MenuItem(mcAssetMenu + mcBuildAsmdefToPackage, false, mcPriority + 3)]
    [MenuItem(mcHierarchy + mcBuildAsmdefToPackage, false, mcPriority + 3)]
    static void EditorReleaseMenuItem_ExecuteBuildAsmdefToPackage()
    {
        EditorStrayFogExecute.ExecuteBuildAsmdefToPackage();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildAsmdefToPackage);
    }
    #endregion

    #region Build All Xls Data
    const string mcBuildAllXlsData = "Build All Xls Data";
    /// <summary>
    /// 生成所有的XLS表数据
    /// </summary>
    [MenuItem(mcMenu + mcBuildAllXlsData, false, mcPriority + 4)]
    [MenuItem(mcAssetMenu + mcBuildAllXlsData, false, mcPriority + 4)]
    [MenuItem(mcHierarchy + mcBuildAllXlsData, false, mcPriority + 4)]
    static void EditorReleaseMenuItem_ExecuteBuildAllXlsData()
    {
        EditorStrayFogExecute.ExecuteBuildAllXlsData();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildAllXlsData);
    }
    #endregion

    #region Copy SQLite Db To Package
    const string mcCopySQLiteDbToPackage = "Copy SQLite Db To Package";
    /// <summary>
    /// 复制SQLite数据库到资源包
    /// </summary>
    [MenuItem(mcMenu + mcCopySQLiteDbToPackage, false, mcPriority + 5)]
    [MenuItem(mcAssetMenu + mcCopySQLiteDbToPackage, false, mcPriority + 5)]
    [MenuItem(mcHierarchy + mcCopySQLiteDbToPackage, false, mcPriority + 5)]
    static void EditorReleaseMenuItem_ExecuteCopySQLiteDbToPackage()
    {
        EditorStrayFogExecute.ExecuteCopySQLiteDbToPackage();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcCopySQLiteDbToPackage);
    }
    #endregion
}
#endif
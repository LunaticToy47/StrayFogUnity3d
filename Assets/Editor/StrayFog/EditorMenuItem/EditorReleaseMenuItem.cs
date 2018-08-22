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
    static void EditorDevelopMenuItem_BuildPackageWindow()
    {
        EditorStrayFogExecute.ExecuteBuildPackage();
        EditorUtility.DisplayDialog("Build Package", "Build Package Complete.", "OK");
    }
    #endregion

    #region Build Delete Nouse Asset Bat To Package
    const string mcBuildDeleteNouseAssetBatToPackage = "Build Delete Nouse Asset Bat To Package";
    /// <summary>
    /// 资源包删除未使用资源批处理
    /// </summary>
    [MenuItem(mcMenu + mcBuildDeleteNouseAssetBatToPackage, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcBuildDeleteNouseAssetBatToPackage, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcBuildDeleteNouseAssetBatToPackage, false, mcPriority + 2)]
    static void EditorDevelopMenuItem_BuildDeleteNouseAssetBatToPackageWindow()
    {
        EditorStrayFogExecute.ExecuteBuildDeleteNouseAssetBatToPackage();
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
    static void EditorDevelopMenuItem_BuildDllToPackageWindow()
    {
        EditorStrayFogExecute.ExecuteBuildDllToPackage();
    }
    #endregion

    #region Build SQLite Db To Package
    const string mcBuildSQLiteDbToPackage = "Build SQLite Db To Package";
    /// <summary>
    /// 生成SQLite数据库到资源包
    /// </summary>
    [MenuItem(mcMenu + mcBuildSQLiteDbToPackage, false, mcPriority + 4)]
    [MenuItem(mcAssetMenu + mcBuildSQLiteDbToPackage, false, mcPriority + 4)]
    [MenuItem(mcHierarchy + mcBuildSQLiteDbToPackage, false, mcPriority + 4)]
    static void EditorDevelopMenuItem_BuildSQLiteDbToPackageWindow()
    {
        EditorStrayFogExecute.ExecuteBuildSQLiteDbToPackage();
    }
    #endregion
}

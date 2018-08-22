using UnityEditor;
/// <summary>
/// SQLite菜单 
/// </summary>
static class EditorSQLiteMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/SQLite/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.SQLite;
    #endregion

    #region Build SQLite Entity
    const string mcBuildSQLiteEntity = "Build SQLite Entity";
    /// <summary>
    /// 生成SQLite表格实体
    /// </summary>
    [MenuItem(mcMenu + mcBuildSQLiteEntity, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildSQLiteEntity, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildSQLiteEntity, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_BuildSQLiteEntityWindow()
    {
        EditorStrayFogExecute.ExecuteBuildSQLiteEntity();
    }
    #endregion
}

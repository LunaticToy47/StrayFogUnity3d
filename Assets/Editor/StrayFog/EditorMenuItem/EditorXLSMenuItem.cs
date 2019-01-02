#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// XLS菜单 
/// </summary>
static class EditorXLSMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/XLS/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.XLS;
    #endregion

    #region Build Xls Schema To Sqlite
    const string mcBuildXlsSchemaToSqlite = "Build Xls Schema To Sqlite";
    /// <summary>
    /// Export Xls Schema To Sqlite
    /// </summary>
    [MenuItem(mcMenu + mcBuildXlsSchemaToSqlite, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildXlsSchemaToSqlite, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildXlsSchemaToSqlite, false, mcPriority + 1)]
    static void EditorXLSMenuItem_BuildXlsSchemaToSqliteWindow()
    {
        EditorBuildXlsSchemaToSqliteWindow win =
               EditorWindow.GetWindow<EditorBuildXlsSchemaToSqliteWindow>(mcBuildXlsSchemaToSqlite);
        win.Show();
    }
    #endregion      
}
#endif
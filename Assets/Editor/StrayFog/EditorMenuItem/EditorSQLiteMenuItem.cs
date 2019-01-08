#if UNITY_EDITOR
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

    #region Export Xls Data To Sqlite
    const string mcExportXlsDataToSqlite = "Export Xls Data To Sqlite";
    /// <summary>
    /// Export Xls Data To Sqlite
    /// </summary>
    [MenuItem(mcMenu + mcExportXlsDataToSqlite, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcExportXlsDataToSqlite, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcExportXlsDataToSqlite, false, mcPriority + 1)]
    static void EditorXLSMenuItem_ExportXlsDataToSqlite()
    {
        EditorStrayFogExecute.ExportXlsDataToSqlite();
    }
    #endregion      
}
#endif

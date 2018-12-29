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

    #region Export Xls Data To Sqlite
    const string mcExportXlsDataToSqlite = "Export Xls Data To Sqlite";
    /// <summary>
    /// Export Xls Data To Sqlite
    /// </summary>
    [MenuItem(mcMenu + mcExportXlsDataToSqlite, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcExportXlsDataToSqlite, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcExportXlsDataToSqlite, false, mcPriority + 2)]
    static void EditorXLSMenuItem_ExportXlsDataToSqliteWindow()
    {
        EditorExportXlsDataToSqliteWindow win =
               EditorWindow.GetWindow<EditorExportXlsDataToSqliteWindow>(mcExportXlsDataToSqlite);
        win.Show();
    }
    #endregion    
}
#endif
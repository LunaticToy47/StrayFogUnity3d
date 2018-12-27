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

    #region Export Xls To Sqlite
    const string mcExportXlsToSqlite = "Export Xls To Sqlite";
    /// <summary>
    /// Export Xls To Sqlite
    /// </summary>
    [MenuItem(mcMenu + mcExportXlsToSqlite, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcExportXlsToSqlite, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcExportXlsToSqlite, false, mcPriority + 1)]
    static void EditorXLSMenuItem_ExportXlsToSqliteWindow()
    {
        EditorExportXlsToSqliteWindow win =
               EditorWindow.GetWindow<EditorExportXlsToSqliteWindow>(mcExportXlsToSqlite);
        win.Show();
    }
    #endregion    

    //Export Xls To Sqlite
}
#endif
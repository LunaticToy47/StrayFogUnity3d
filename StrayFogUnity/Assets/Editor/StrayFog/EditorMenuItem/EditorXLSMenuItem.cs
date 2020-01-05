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

    #region Build Xls Schema To Sqlite Script
    const string mcBuildXlsSchemaToSqliteAndScript = "Build Xls Schema To Sqlite And Script";
    /// <summary>
    /// Export Xls Schema To Sqlite And Script
    /// </summary>
    [MenuItem(mcMenu + mcBuildXlsSchemaToSqliteAndScript, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildXlsSchemaToSqliteAndScript, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildXlsSchemaToSqliteAndScript, false, mcPriority + 1)]
    static void EditorXLSMenuItem_EditorWindowBuildXlsSchemaToSqliteAndScript()
    {
        EditorWindowBuildXlsSchemaToSqliteAndScript win =
               EditorWindow.GetWindow<EditorWindowBuildXlsSchemaToSqliteAndScript>(mcBuildXlsSchemaToSqliteAndScript);
        win.Show();
    }
    #endregion      
}
#endif
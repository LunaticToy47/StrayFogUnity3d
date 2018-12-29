﻿#if UNITY_EDITOR
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

    #region Build SQLite Entity
    const string mcBuildSQLiteEntity = "Build SQLite Entity";
    /// <summary>
    /// 生成SQLite表格实体
    /// </summary>
    [MenuItem(mcMenu + mcBuildSQLiteEntity, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcBuildSQLiteEntity, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcBuildSQLiteEntity, false, mcPriority + 2)]
    static void EditorDevelopMenuItem_BuildSQLiteEntityWindow()
    {
        EditorStrayFogExecute.ExecuteBuildSQLiteEntity();
    }
    #endregion
}
#endif

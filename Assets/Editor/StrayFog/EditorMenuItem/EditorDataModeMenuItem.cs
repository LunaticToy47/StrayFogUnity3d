#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
/// <summary>
/// 数据模式菜单
/// </summary>
static class EditorDataModeMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/DataMode/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.DataMode;
    #endregion

    #region XLS数据
    const string mcDTMXLS = "Use XLS Data";
    /// <summary>
    /// XLS数据
    /// </summary>
    [MenuItem(mcMenu + mcDTMXLS, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcDTMXLS, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcDTMXLS, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_DTMXLS()
    {
        OnEditorToggleDataMode(true);
    }
    /// <summary>
    /// XLS数据
    /// </summary>
    [MenuItem(mcMenu + mcDTMXLS, true, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcDTMXLS, true, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcDTMXLS, true, mcPriority + 1)]
    static bool EditorDevelopMenuItem_DTMXLSValidate()
    {
        bool canSelect = StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseSQLite;
        canSelect &= StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isInternal;
        return canSelect;
    }
#endregion

#region SQLite数据
    const string mcDTMSQLite = "Use SQLite Data";
    /// <summary>
    /// SQLite数据
    /// </summary>
    [MenuItem(mcMenu + mcDTMSQLite, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcDTMSQLite, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcDTMSQLite, false, mcPriority + 2)]
    static void EditorDevelopMenuItem_DTMSQLite()
    {
        OnEditorToggleDataMode(false);
    }
    /// <summary>
    /// SQLite数据
    /// </summary>
    [MenuItem(mcMenu + mcDTMSQLite, true, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcDTMSQLite, true, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcDTMSQLite, true, mcPriority + 2)]
    static bool EditorDevelopMenuItem_DTMSQLiteValidate()
    {
        bool canSelect = !StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isUseSQLite;
        canSelect &= StrayFogRunningUtility.SingleScriptableObject<StrayFogSetting>().isInternal;
        return canSelect;
    }
#endregion

#region OnEditorToggleDataMode 切换数据模式
    /// <summary>
    /// 切换数据模式
    /// </summary>
    /// <param name="_isXLSData">是否是XLS数据</param>
    static void OnEditorToggleDataMode(bool _isXLSData)
    {
        string forceusesqlite = enSystemDefine.FORCEUSESQLITE.ToString();
        List<string> saveDefines = new List<string>();
        string[] symbol = EditorStrayFogApplication.GetScriptingDefineSymbolsForGroup();
        if (symbol != null)
        {
            foreach (string s in symbol)
            {
                saveDefines.Add(s);
            }
        }
        if (_isXLSData)
        {
            saveDefines.Remove(forceusesqlite);
        }
        else
        {
            if (!saveDefines.Contains(forceusesqlite))
            {
                saveDefines.Add(forceusesqlite);
            }
        }
        EditorStrayFogApplication.SetScriptingDefineSymbolsForGroup(saveDefines.ToArray());
        EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
    }
#endregion
}
#endif
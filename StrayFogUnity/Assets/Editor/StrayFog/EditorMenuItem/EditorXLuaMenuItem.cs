#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// XLS菜单 
/// </summary>
static class EditorXLuaMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/XLua/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.XLua;
    #endregion

    #region Build XLua Map
    const string mcBuildXLuaMap = "Build XLua Map";
    /// <summary>
    /// Build XLua Map
    /// </summary>
    [MenuItem(mcMenu + mcBuildXLuaMap, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildXLuaMap, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildXLuaMap, false, mcPriority + 1)]
    static void EditorXLSMenuItem_BuildXLuaMapWindow()
    {
        EditorBuildXLuaMapWindow win =
               EditorWindow.GetWindow<EditorBuildXLuaMapWindow>(mcBuildXLuaMap);
        win.Show();
    }
    #endregion      
}
#endif
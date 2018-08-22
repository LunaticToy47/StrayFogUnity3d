using UnityEditor;
/// <summary>
/// 开发菜单 
/// </summary>
static class EditorDevelopMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Develop/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Develop;
    #endregion

    #region MacroDefine
    const string mcMacroDefine = "MacroDefineSymbols";
    /// <summary>
    /// 脚本编译宏符号
    /// </summary>
    [MenuItem(mcMenu + mcMacroDefine, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcMacroDefine, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcMacroDefine, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_MacroDefineScriptingDefineSymbolsWindow()
    {
        EditorWindowMacroDefineScriptingDefineSymbols win =
        EditorWindow.GetWindow<EditorWindowMacroDefineScriptingDefineSymbols>(mcMacroDefine);
        win.Show();
    }
    #endregion
}

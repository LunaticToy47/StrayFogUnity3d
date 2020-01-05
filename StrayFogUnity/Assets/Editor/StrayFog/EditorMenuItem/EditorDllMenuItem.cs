#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// Dll菜单 
/// </summary>
static class EditorDllMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Dll/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Dll;
    #endregion

    #region Look Package Dll
    const string mcLookPackageDll = "Look Package Dll";
    /// <summary>
    /// 查看可打包的dll
    /// </summary>
    [MenuItem(mcMenu + mcLookPackageDll, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcLookPackageDll, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcLookPackageDll, false, mcPriority + 1)]
    static void EditorDllMenuItem_LookPackageDllWindow()
    {
        EditorStrayFogExecute.ExecuteLookPackageDll();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcLookPackageDll);
    }
    #endregion

    #region Dynamic Create Dll
    const string mcDynamicCreateDll = "Dynamic Create Dll";
    /// <summary>
    /// 动态生成Dll
    /// </summary>
    [MenuItem(mcMenu + mcDynamicCreateDll, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcDynamicCreateDll, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcDynamicCreateDll, false, mcPriority + 2)]
    static void EditorDllMenuItem_EditorWindowDynamicCreateDll()
    {
        EditorWindowDynamicCreateDll win =
        EditorWindow.GetWindow<EditorWindowDynamicCreateDll>(mcDynamicCreateDll);
        win.Show();
    }
    #endregion
}
#endif

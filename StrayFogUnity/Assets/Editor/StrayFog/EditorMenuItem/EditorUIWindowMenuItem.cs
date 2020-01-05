#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// UIWindow菜单 
/// </summary>
static class EditorUIWindowMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/UIWindow/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.UIWindow;
    #endregion

    #region Create New UIWindow
    const string mcCreateNewUIWindow = "Create New UIWindow";
    /// <summary>
    /// 创建新的UI窗口
    /// </summary>
    [MenuItem(mcMenu + mcCreateNewUIWindow, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcCreateNewUIWindow, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcCreateNewUIWindow, false, mcPriority + 1)]
    static void EditorUIWindowMenuItem_CreateNewUIWindowWindow()
    {
        EditorWindowCreateNewUI win =
              EditorWindow.GetWindow<EditorWindowCreateNewUI>(mcCreateNewUIWindow);
        win.Show();
    }
    #endregion

    #region Build UIWindow Maping
    const string mcBuildUIWindowMaping = "Build UIWindow Maping";
    /// <summary>
    /// 生成窗口映射
    /// </summary>
    [MenuItem(mcMenu + mcBuildUIWindowMaping, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildUIWindowMaping, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildUIWindowMaping, false, mcPriority + 1)]
    static void EditorUIWindowMenuItem_EditorWindowBuildUIWindowMaping()
    {
        EditorWindowBuildUIWindowMaping win =
              EditorWindow.GetWindow<EditorWindowBuildUIWindowMaping>(mcBuildUIWindowMaping);
        win.Show();
    }
    #endregion
}
#endif

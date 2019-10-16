#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 引导菜单 
/// </summary>
static class EditorGuideMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Guide/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Guide;
    #endregion

    #region mcGuideManager
    const string mcGuideManager = "Guide Manager";
    /// <summary>
    /// 引导管理窗口
    /// </summary>
    [MenuItem(mcMenu + mcGuideManager, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcGuideManager, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcGuideManager, false, mcPriority + 1)]
    static void EditorGuideMenuItem_EditorWindowGuideManagerWindow()
    {
        EditorWindowGuideManagerWindow win =
        EditorWindow.GetWindow<EditorWindowGuideManagerWindow>(mcGuideManager);
        win.Show();
    }
    #endregion
}
#endif

#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 自定义资源菜单 
/// </summary>
static class EditorCustomAssetMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/CustomAsset/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.CustomAsset;
    #endregion

    #region CustomAsset
    const string mcCustomAsset = "New Asset";
    /// <summary>
    /// 脚本编译宏符号
    /// </summary>
    [MenuItem(mcMenu + mcCustomAsset, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcCustomAsset, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcCustomAsset, false, mcPriority + 1)]
    static void EditorCustomAssetMenuItem_EditorWindowCustomAssetCreateNewAsset()
    {
        EditorWindowCustomAssetCreateNewAsset win =
        EditorWindow.GetWindow<EditorWindowCustomAssetCreateNewAsset>(mcCustomAsset);
        win.ShowUtility();
    }
    #endregion
}
#endif
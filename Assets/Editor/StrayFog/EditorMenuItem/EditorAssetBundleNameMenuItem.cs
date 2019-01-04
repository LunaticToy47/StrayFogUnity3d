#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// 开发菜单 
/// </summary>
static class EditorAssetBundleNameMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/AssetBundle/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.AssetBundleName;
    #endregion

    #region SetAssetBundleName
    const string mcSetAssetBundleName = "SetAssetBundleName";
    /// <summary>
    /// 设置AssetBundleName
    /// </summary>
    [MenuItem(mcMenu + mcSetAssetBundleName, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcSetAssetBundleName, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcSetAssetBundleName, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_SetAssetBundleNameWindow()
    {
        if (EditorStrayFogApplication.IsExecuteMethodInCmd())
        {
            EditorStrayFogExecute.ExecuteSetAssetBundleName();
        }
        else
        {
            EditorWindowSetAssetBundleName win =
               EditorWindow.GetWindow<EditorWindowSetAssetBundleName>(mcSetAssetBundleName);
            win.Show();
        }
    }
    #endregion

    #region Clear All AssetBundleName
    const string mcClearAllAssetBundleName = "Clear All AssetBundleName";
    /// <summary>
    /// 清除所有AssetBundleName
    /// </summary>
    [MenuItem(mcMenu + mcClearAllAssetBundleName, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcClearAllAssetBundleName, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcClearAllAssetBundleName, false, mcPriority + 2)]
    public static void EditorDevelopMenuItem_ClearAllAssetBundleNameWindow()
    {
        if (EditorStrayFogApplication.IsExecuteMethodInCmd() || EditorUtility.DisplayDialog("Clear All AssetBundleName", "Are you srue clear all AssetBundleName?", "Yes", "No"))
        {
            EditorStrayFogExecute.ExecuteClearAllAssetBundleName();
        }
    }
    #endregion
}
#endif
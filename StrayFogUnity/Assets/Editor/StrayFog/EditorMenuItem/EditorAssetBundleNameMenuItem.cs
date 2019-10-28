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
    const string mcSetAssetBundleName = "Set AssetBundleName";
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
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcSetAssetBundleName);
        }
        else
        {
            EditorWindowSetAssetBundleName win =
               EditorWindow.GetWindow<EditorWindowSetAssetBundleName>(mcSetAssetBundleName);
            win.Show();
        }
    }
    #endregion

    #region  Query AssetBundle AssetDiskMaping Data
    const string mcQueryAssetBundleAssetDiskMapingData = "Query AssetBundle AssetDiskMaping Data";
    /// <summary>
    /// 查询指定资源文件的磁盘映射值
    /// </summary>
    [MenuItem(mcMenu + mcQueryAssetBundleAssetDiskMapingData, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcQueryAssetBundleAssetDiskMapingData, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcQueryAssetBundleAssetDiskMapingData, false, mcPriority + 2)]
    public static void EditorDevelopMenuItem_QueryAssetBundleAssetDiskMapingDataWindow()
    {
        if (Selection.activeObject != null)
        {
            EditorSelectionAssetDiskMaping asset = new EditorSelectionAssetDiskMaping(AssetDatabase.GetAssetPath(Selection.activeObject));
            asset.Resolve();
            string log = string.Format("{0}=>fileId:{1} folderId:{2}", Selection.activeObject, asset.fileId, asset.folderId);
            EditorStrayFogApplication.CopyToClipboard(log);
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcQueryAssetBundleAssetDiskMapingData);
            UnityEngine.Debug.Log(log);
        }
    }
    #endregion

    #region Clear All AssetBundleName
    const string mcClearAllAssetBundleName = "Clear All AssetBundleName";
    /// <summary>
    /// 清除所有AssetBundleName
    /// </summary>
    [MenuItem(mcMenu + mcClearAllAssetBundleName, false, mcPriority + 3)]
    [MenuItem(mcAssetMenu + mcClearAllAssetBundleName, false, mcPriority + 3)]
    [MenuItem(mcHierarchy + mcClearAllAssetBundleName, false, mcPriority + 3)]
    public static void EditorDevelopMenuItem_ClearAllAssetBundleNameWindow()
    {
        if (EditorStrayFogApplication.IsExecuteMethodInCmd() || EditorUtility.DisplayDialog(mcClearAllAssetBundleName, "Are you sure 【"+ mcClearAllAssetBundleName + "】?", "Yes", "No"))
        {
            EditorStrayFogExecute.ExecuteClearAllAssetBundleName();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcClearAllAssetBundleName);
        }
    }
    #endregion
}
#endif
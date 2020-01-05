#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 精灵图集菜单 
/// </summary>
static class EditorSpriteAtlasMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/SpriteAtlas/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.SpriteAtlas;
    #endregion

    #region SetSpritePackingTag
    const string mcSetSpritePackingTag = "Set Sprite Packing Tag";
    /// <summary>
    /// 设置精灵图集Tag
    /// </summary>
    [MenuItem(mcMenu + mcSetSpritePackingTag, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcSetSpritePackingTag, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcSetSpritePackingTag, false, mcPriority + 1)]
    static void EditorSpriteAtlasMenuItem_EditorWindowSetSpritePackingTag()
    {
        if (EditorStrayFogApplication.IsExecuteMethodInCmd())
        {
            EditorStrayFogExecute.ExecuteSetSpritePackingTag();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcSetSpritePackingTag);
        }
        else
        {
            EditorWindowSetSpritePackingTag win =
               EditorWindow.GetWindow<EditorWindowSetSpritePackingTag>(mcSetSpritePackingTag);
            win.Show();
        }
    }
    #endregion

    #region ClearSpritePackingTag
    const string mcClearSpritePackingTag = "Clear Sprite Packing Tag";
    /// <summary>
    /// 清除精灵图集Tag
    /// </summary>
    [MenuItem(mcMenu + mcClearSpritePackingTag, false, mcPriority + 2)]
    [MenuItem(mcAssetMenu + mcClearSpritePackingTag, false, mcPriority + 2)]
    [MenuItem(mcHierarchy + mcClearSpritePackingTag, false, mcPriority + 2)]
    static void EditorSpriteAtlasMenuItem_ExecuteClearSpritePackingTag()
    {
        EditorStrayFogExecute.ExecuteClearSpritePackingTag();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcClearSpritePackingTag);
    }
    #endregion

    #region ClearAllSpritePackingTag
    const string mcClearAllSpritePackingTag = "Clear All Sprite Packing Tag";
    /// <summary>
    /// 清除精灵图集Tag
    /// </summary>
    [MenuItem(mcMenu + mcClearAllSpritePackingTag, false, mcPriority + 3)]
    [MenuItem(mcAssetMenu + mcClearAllSpritePackingTag, false, mcPriority + 3)]
    [MenuItem(mcHierarchy + mcClearAllSpritePackingTag, false, mcPriority + 3)]
    static void EditorSpriteAtlasMenuItem_ExecuteClearAllSpritePackingTag()
    {
        EditorStrayFogExecute.ExecuteClearAllSpritePackingTag();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcClearAllSpritePackingTag);
    }
    #endregion
}
#endif

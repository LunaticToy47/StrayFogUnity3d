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

    #region mcSetUIGuideRegister_GraphicNodeIndexs
    const string mcSetUIGuideRegister_GraphicNodeIndexs = "Set UIGuideRegister.GraphicNodeIndexs";
    /// <summary>
    /// 设置UIGuideRegister的GraphicNodeIndexs参数值
    /// </summary>
    [MenuItem(mcMenu + mcSetUIGuideRegister_GraphicNodeIndexs, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcSetUIGuideRegister_GraphicNodeIndexs, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcSetUIGuideRegister_GraphicNodeIndexs, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_FindUIGuideRegister_GraphicNodeIndexsWindow()
    {
        EditorWindowSetUIGuideRegister_GraphicNodeIndexs win =
        EditorWindow.GetWindow<EditorWindowSetUIGuideRegister_GraphicNodeIndexs>(mcSetUIGuideRegister_GraphicNodeIndexs);
        win.Show();
    }
    #endregion

    #region mcFindUIGuideRegister_GraphicNodeIndexs_Graphic
    const string mcFindUIGuideRegister_GraphicNodeIndexs_Graphic = "Find UIGuideRegister.GraphicNodeIndexs Graphic";
    /// <summary>
    /// 查找引导注册器指定的Graphic
    /// </summary>
    [MenuItem(mcMenu + mcFindUIGuideRegister_GraphicNodeIndexs_Graphic, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcFindUIGuideRegister_GraphicNodeIndexs_Graphic, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcFindUIGuideRegister_GraphicNodeIndexs_Graphic, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_FindUIGuideRegister_GraphicNodeIndexs_Graphic()
    {
        EditorStrayFogExecute.ExecuteFindUIGuideRegisterMaskGraphic();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcFindUIGuideRegister_GraphicNodeIndexs_Graphic);
    }
    #endregion
}
#endif

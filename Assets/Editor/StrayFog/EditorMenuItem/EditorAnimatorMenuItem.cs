#if UNITY_EDITOR 
using UnityEditor;
/// <summary>
/// Animator菜单 
/// </summary>
static class EditorAnimatorMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Animator/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Animator;
    #endregion

    #region Build Animator Controller FMS Maping
    const string mcBuildAnimatorControllerFMSMaping = "Build Animator Controller FMS Maping";
    /// <summary>
    /// 生成Animator Controller FMS 映射
    /// </summary>
    [MenuItem(mcMenu + mcBuildAnimatorControllerFMSMaping, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildAnimatorControllerFMSMaping, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildAnimatorControllerFMSMaping, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_BuildAnimatorControllerFMSMapingWindow()
    {
        if (EditorStrayFogApplication.IsExecuteMethodInCmd())
        {
            EditorStrayFogExecute.ExecuteBuildAnimatorControllerFMSMaping();
            EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildAnimatorControllerFMSMaping);
        }
        else
        {
            EditorWindowAnimatorControllerFMSMaping win =
               EditorWindow.GetWindow<EditorWindowAnimatorControllerFMSMaping>(mcBuildAnimatorControllerFMSMaping);
            win.Show();
        }
    }
    #endregion
}
#endif
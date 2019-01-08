#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// Shader菜单
/// </summary>
static class EditorShaderMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/Shader/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.Shader;
    #endregion

    #region Build Default Shader
    const string mcBuildDefaultShader = "Build Default Shader";
    /// <summary>
    /// 创建默认Shader
    /// </summary>
    [MenuItem(mcMenu + mcBuildDefaultShader, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildDefaultShader, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildDefaultShader, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_BuildDefaultShader()
    {
        EditorStrayFogExecute.ExecuteBuildDefaultShader();
        EditorStrayFogApplication.MenuItemQuickDisplayDialogSucceed(mcBuildDefaultShader);
    }
    #endregion
}
#endif
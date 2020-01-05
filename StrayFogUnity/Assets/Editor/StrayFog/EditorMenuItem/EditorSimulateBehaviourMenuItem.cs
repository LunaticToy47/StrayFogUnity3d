#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 模拟Behaviour菜单
/// </summary>
static class EditorSimulateBehaviourMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/SimulateBehaviour/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.SimulateBehaviour;
    #endregion

    #region Build Simulate Behaviour Method
    const string mcBuildSimulateBehaviourMethod = "Build SimulateBehaviour Method";
    /// <summary>
    /// 构建模拟Behaviour事件控件
    /// </summary>
    [MenuItem(mcMenu + mcBuildSimulateBehaviourMethod, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildSimulateBehaviourMethod, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildSimulateBehaviourMethod, false, mcPriority + 1)]
    static void EditorSimulateBehaviourMenuItem_EditorWindowBuildSimulateBehaviourMethod()
    {
        EditorWindowBuildSimulateBehaviourMethod win =
              EditorWindow.GetWindow<EditorWindowBuildSimulateBehaviourMethod>(mcBuildSimulateBehaviourMethod);
        win.Show();
    }
    #endregion
}
#endif

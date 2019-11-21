#if UNITY_EDITOR
using UnityEditor;
/// <summary>
/// 模拟MonoBehaviour菜单
/// </summary>
static class EditorSimulateMonoBehaviourMenuItem
{
    #region 常量
    /// <summary>
    /// 菜单
    /// </summary>
    const string mcMenu = "StrayFog/SimulateMonoBehaviour/";
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
    const int mcPriority = 100 * (int)enEditorMenuItemPriority.SimulateMonoBehaviour;
    #endregion

    #region Build Simulate MonoBehaviour Method
    const string mcBuildSimulateMonoBehaviourMethod = "Build Simulate MonoBehaviour Method";
    /// <summary>
    /// 构建模拟MonoBehaviour事件控件
    /// </summary>
    [MenuItem(mcMenu + mcBuildSimulateMonoBehaviourMethod, false, mcPriority + 1)]
    [MenuItem(mcAssetMenu + mcBuildSimulateMonoBehaviourMethod, false, mcPriority + 1)]
    [MenuItem(mcHierarchy + mcBuildSimulateMonoBehaviourMethod, false, mcPriority + 1)]
    static void EditorDevelopMenuItem_BuildSimulateMonoBehaviourMethodWindow()
    {
        EditorWindowBuildSimulateMonoBehaviourMethod win =
              EditorWindow.GetWindow<EditorWindowBuildSimulateMonoBehaviourMethod>(mcBuildSimulateMonoBehaviourMethod);
        win.Show();
    }
    #endregion
}
#endif

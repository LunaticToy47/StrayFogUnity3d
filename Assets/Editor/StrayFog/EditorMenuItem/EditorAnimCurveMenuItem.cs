using StrayFogEditor.EditorWizardWindows.AnimCurve;
using UnityEditor;

namespace StrayFogEditor.EditorMenuItem
{
    /// <summary>
    /// AnimCurve菜单 
    /// </summary>
    static class EditorAnimCurveMenuItem
    {
        #region 常量
        /// <summary>
        /// 菜单
        /// </summary>
        const string mcMenu = "StrayFog/AnimCurve/";
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
        const int mcPriority = 100 * (int)enEditorMenuItemPriority.AnimCurve;
        #endregion

        #region Build Curves
        const string mcBuildAnimCurves = "Build Anim Curves";
        /// <summary>
        /// 生成曲线
        /// </summary>
        [MenuItem(mcMenu + mcBuildAnimCurves, false, mcPriority + 1)]
        [MenuItem(mcAssetMenu + mcBuildAnimCurves, false, mcPriority + 1)]
        [MenuItem(mcHierarchy + mcBuildAnimCurves, false, mcPriority + 1)]
        static void EditorDevelopMenuItem_BuildAnimCurvesWindow()
        {
            EditorStrayFogExecute.ExecuteBuildAnimCurves();
        }
        #endregion
    }
}

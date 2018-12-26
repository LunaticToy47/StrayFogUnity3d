#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
/// <summary>
/// 设置窗口
/// </summary>
public class EditorWindowSettingUIWindow : AbsEditorWindow
{
    /// <summary>
    /// 滚动视图位置
    /// </summary>
    Vector2 mScrollViewPosition = Vector2.zero;
    /// <summary>
    /// 窗口
    /// </summary>
    EditorSelectionUIWindowSetting mWindow;
    /// <summary>
    /// OnGUI
    /// </summary>
    void OnGUI()
    {
        if (mWindow != null)
        {
            #region 绘制属性
            EditorGUILayout.LabelField(string.Format("{0}【{1}】", mWindow.nameWithoutExtension, mWindow.winId));
            //RenderMode
            mWindow.assetNode.renderMode = (RenderMode)EditorStrayFogUtility.guiLayout.EnumPopup(mWindow.assetNode.renderMode, new GUIContent("RenderMode"));
            //enUIWindowLayer
            mWindow.assetNode.layer = (enUIWindowLayer)EditorStrayFogUtility.guiLayout.EnumPopup(mWindow.assetNode.layer, new GUIContent("窗口层级"));
            //enUIWindowOpenMode
            mWindow.assetNode.openMode = (enUIWindowOpenMode)EditorStrayFogUtility.guiLayout.EnumPopup(mWindow.assetNode.openMode, new GUIContent("打开模式"));
            //enUIWindowCloseMode
            mWindow.assetNode.closeMode = (enUIWindowCloseMode)EditorStrayFogUtility.guiLayout.EnumPopup(mWindow.assetNode.closeMode, new GUIContent("关闭模式"));

            //isIgnoreOpenCloseMode
            mWindow.assetNode.isIgnoreOpenCloseMode = EditorGUILayout.Toggle("是否忽略开启关闭模式", mWindow.assetNode.isIgnoreOpenCloseMode);
            //isDonotDestroyInstance
            mWindow.assetNode.isDonotDestroyInstance = EditorGUILayout.Toggle("是否是不可销毁实例", mWindow.assetNode.isDonotDestroyInstance);
            //isNotAutoRestoreSequenceWindow
            mWindow.assetNode.isNotAutoRestoreSequenceWindow = EditorGUILayout.Toggle("是否是不可自动恢复序列窗口", mWindow.assetNode.isNotAutoRestoreSequenceWindow);
            //是否立即显示窗口
            mWindow.assetNode.isImmediateDisplay = EditorGUILayout.Toggle("是否立即显示窗口", mWindow.assetNode.isImmediateDisplay);
            //跳转场景时是否手动关闭
            mWindow.assetNode.isManualCloseWhenGotoScene = EditorGUILayout.Toggle("跳转场景时是否手动关闭", mWindow.assetNode.isManualCloseWhenGotoScene);
            //是否是引导窗口
            mWindow.assetNode.isGuideWindow = EditorGUILayout.Toggle("是否是引导窗口", mWindow.assetNode.isGuideWindow);
            #endregion

            #region 保存设置
            if (GUILayout.Button("Save Window Setting"))
            {
                Debug.Log(mWindow.ExecuteUpdateUIWindowSetting());
                EditorStrayFogApplication.ExecuteMenu_AssetsRefresh();
                EditorUtility.DisplayDialog("Save Window Setting", "Save Window Setting Success", "OK");

            }
            #endregion
        }
    }

    /// <summary>
    /// 设置窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    public void SetWindow(EditorSelectionUIWindowSetting _window)
    {
        mWindow = _window;
    }
}
#endif
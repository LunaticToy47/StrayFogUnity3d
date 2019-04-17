using UnityEngine;
/// <summary>
/// 窗口占位符
/// </summary>

[AddComponentMenu("Game/UI/UIWindowHolder")]
public class UIWindowHolder : AbsMonoBehaviour
{
    #region SetWindowCanvas 设置窗口画布
    /// <summary>
    /// 窗口画布
    /// </summary>
    UICanvas mWindowCanvas;
    /// <summary>
    /// 设置窗口画布
    /// </summary>
    /// <param name="_canvas">窗口画布</param>
    public void SetWindowCanvas(UICanvas _canvas)
    {
        mWindowCanvas = _canvas;
    }
    #endregion

    #region SetWindowConfig 设置窗口配置
    /// <summary>
    /// 窗口配置
    /// </summary>
    public XLS_Config_Table_UIWindowSetting winCfg { get; private set; }
    /// <summary>
    /// 设置窗口配置
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    public void SetWindowConfig(XLS_Config_Table_UIWindowSetting _winCfg)
    {
        winCfg = _winCfg;
    }
    #endregion

    #region MarkLoadedWindowInstace 标记已加载窗口实例
    /// <summary>
    /// 是否标记已加载窗口实例
    /// </summary>
    public bool isMarkLoadedWindowInstace { get; private set; }
    /// <summary>
    /// 标记已加载窗口实例
    /// </summary>
    public void MarkLoadedWindowInstace()
    {
        isMarkLoadedWindowInstace = true;
    }
    #endregion

    #region SetWindow 设置窗口实例
    /// <summary>
    /// 窗口实例
    /// </summary>
    public AbsUIWindowView window { get; private set; }
    /// <summary>
    /// 窗口SiblingIndex
    /// </summary>
    public int windowSiblingIndex { get { return transform.GetSiblingIndex(); } }
    /// <summary>
    /// 设置窗口实例
    /// </summary>
    /// <typeparam name="W">类型</typeparam>
    /// <param name="_window">窗口实例</param>
    public void SetWindow<W>(W _window)
        where W : AbsUIWindowView
    {
        window = _window;
        mWindowCanvas.AttachWindow(_window);
    }

    /// <summary>
    /// 是否有指定窗口实例
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <returns>true:有,false:无</returns>
    public bool HasWindowInstance<W>()
        where W : AbsUIWindowView
    {
        return window != null && window is W;
    }
    #endregion

    #region ToggleSiblingIndex 变更SiblingIndex
    /// <summary>
    /// 变更SiblingIndex
    /// </summary>
    public void ToggleSiblingIndex()
    {
        if (window != null)
        {
            window.rectTransform.SetSiblingIndex(windowSiblingIndex);
        }
    }
    #endregion

    #region ToggleActive 切换状态
    /// <summary>
    /// 切换状态
    /// </summary>
    public void ToggleActive()
    {
        if (window != null)
        {
            window.ToggleActive(mTargetActive);
        }
    }
    #endregion

    #region SetTargetActive 设置要变更的状态
    /// <summary>
    /// 要变更的状态
    /// </summary>
    bool mTargetActive = false;
    /// <summary>
    /// 切换状态
    /// </summary>
    /// <param name="_isActive">是否激活</param>
    public void SetTargetActive(bool _isActive)
    {
        mTargetActive = _isActive;
    }
    #endregion

    #region OnRecycle 回收占位符
    /// <summary>
    /// OnRecycle
    /// </summary>
    protected override void OnRecycle()
    {
        isMarkLoadedWindowInstace = false;
        if (window != null)
        {
            Destroy(window.gameObject);
        }
        window = null;
        mTargetActive = false;
        base.OnRecycle();
    }
    #endregion
}
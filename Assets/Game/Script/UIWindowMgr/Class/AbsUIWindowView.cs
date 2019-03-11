using System.Collections;
using UnityEngine;
/// <summary>
/// 窗口开关句柄
/// </summary>
/// <param name="_window">窗口</param>
public delegate void UIWindowOnOffEventHandle(AbsUIWindowView _window);
/// <summary>
/// 窗口视图
/// </summary>
public abstract class AbsUIWindowView : AbsMonoBehaviour
{
    #region config 窗口配置
    /// <summary>
    /// 窗口配置
    /// </summary>
    public XLS_Config_Table_UIWindowSetting config { get; private set; }
    #endregion

    #region SetConfig 设置设定
    /// <summary>
    /// 设置设定
    /// </summary>
    /// <param name="_cfg">设定</param>
    public void SetConfig(XLS_Config_Table_UIWindowSetting _cfg)
    {
        config = _cfg;
    }
    #endregion

    #region RectTransform
    /// <summary>
    /// RectTransform
    /// </summary>
    RectTransform mRectTransform;
    /// <summary>
    /// rectTransform
    /// </summary>
    public RectTransform rectTransform { get { if (mRectTransform == null) { mRectTransform = gameObject.GetComponent<RectTransform>(); } return mRectTransform; } }
    #endregion

    #region ToggleActive 切换激活状态
    /// <summary>
    /// 是否是第一次显示
    /// </summary>
    bool mIsFirstDisplay = true;
    /// <summary>
    /// 立即设置激活状态
    /// </summary>
    /// <param name="_isActive">是否激活</param>
    public void ToggleActive(bool _isActive)
    {
        if (gameObject.activeSelf != _isActive)
        {
            if (_isActive)
            {
                if (mIsFirstDisplay)
                {
                    mIsFirstDisplay = false;
                    OnInitialize();
                }
                OnBeforeDisplay();
                rectTransform.gameObject.SetActive(_isActive);
                OnAfterDisplay();
            }
            else
            {
                OnBeforeHidden();
                rectTransform.gameObject.SetActive(_isActive);
                OnAfterHidden();
            }
        }
    }

    #region protected virtual methods
    /// <summary>
    /// 窗口初始化
    /// </summary>
    protected virtual void OnInitialize() { }
    /// <summary>
    /// 显示窗口之前
    /// </summary>
    protected virtual void OnBeforeDisplay() { }
    /// <summary>
    /// 显示窗口之后
    /// </summary>
    protected virtual void OnAfterDisplay() { }
    /// <summary>
    /// 隐藏窗口之前
    /// </summary>
    protected virtual void OnBeforeHidden() { }
    /// <summary>
    /// 隐藏窗口之后
    /// </summary>
    protected virtual void OnAfterHidden() { }
    #endregion
    #endregion

    #region CloseWindow
    /// <summary>
    /// 关闭窗口事件
    /// </summary>
    public event UIWindowOnOffEventHandle OnCloseWindow;
    /// <summary>
    /// 关闭窗口
    /// </summary>
    public void CloseWindow()
    {
        if (OnCloseWindow != null)
        {
            OnCloseWindow(this);
        }        
    }
    #endregion
}
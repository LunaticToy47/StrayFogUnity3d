using UnityEngine;
/// <summary>
/// 引导窗口视图
/// </summary>
public abstract class AbsUIGuideWindowView : AbsUIWindowView
{
    /// <summary>
    /// 切换背景显示
    /// </summary>
    /// <param name="_isDisplay">是否显示背景</param>
    public abstract void ToggleBackgroundDisplay(bool _isDisplay);

    /// <summary>
    /// 添加引导项
    /// </summary>
    /// <param name="_guideWidgets">引导控件组</param>
    public abstract void AddTrigger(params UIGuideTrigger[] _guideWidgets);

    /// <summary>
    /// 移除引导项
    /// </summary>
    /// <param name="_guideWidget">引导控件组</param>
    public abstract void RemoveTrigger(params UIGuideTrigger[] _guideWidgets);

    /// <summary>
    /// 清除引导项
    /// </summary>
    public abstract void ClearTrigger();
}
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 是否是指定关卡事件代理
/// </summary>
/// <param name="_levelId">关卡id</param>
/// <returns>true:是指定关卡,false:不是指定关卡</returns>
public delegate bool IsLevelEventHandler(int _levelId);
/// <summary>
/// 指定窗口是否打开事件代理
/// </summary>
/// <param name="_windowId">窗口id</param>
/// <returns>true:指定窗口已打开,false:指定窗口未打开</returns>
public delegate bool IsWindowOpenedEventHandler(int _windowId);
/// <summary>
/// 触发器完成事件代理
/// </summary>
/// <param name="_trigger">触发器</param>
public delegate void GuideTriggerFinishedEventHandler(UIGuideTrigger _trigger);
/// <summary>
/// 引导管理器
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogGuideManager")]
public partial class StrayFogGuideManager : AbsSingleMonoBehaviour
{
    #region OnIsLevel 是否是指定关卡
    /// <summary>
    /// 是否是指定关卡
    /// </summary>
    public event IsLevelEventHandler OnIsLevel;
    #endregion

    #region OnIsWindowOpened 指定窗口是否打开
    /// <summary>
    /// 指定窗口是否打开
    /// </summary>
    public event IsWindowOpenedEventHandler OnWindowIsOpened;
    #endregion

    #region OnTriggerFinished 触发器完成事件
    /// <summary>
    /// 触发器完成事件
    /// </summary>
    public event GuideTriggerFinishedEventHandler OnTriggerFinished;
    #endregion

    #region OnAfterConstructor
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        OnInitGuideWindowData();
        OnInitGuideConfigData();
    }
    #endregion
}

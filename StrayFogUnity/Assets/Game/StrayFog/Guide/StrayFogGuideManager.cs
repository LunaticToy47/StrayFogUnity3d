using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
public class StrayFogGuideManager : AbsSingleMonoBehaviour
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
    /// 引导窗口
    /// </summary>
    AbsUIGuideWindowView mGuideWindow;
    /// <summary>
    /// 触发配置映射
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideConfig> mGuideConfigMaping = new Dictionary<int, XLS_Config_Table_UserGuideConfig>();
    /// <summary>
    /// 等待触发引导
    /// </summary>
    List<int> mWaitTriggerGuides = new List<int>();
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        #region 初始化引导窗口
        List<XLS_Config_Table_UIWindowSetting> guides = StrayFogGamePools.uiWindowManager.GetWindowSettings((w) => { return w.isGuideWindow; });
        if (guides != null && guides.Count > 0)
        {
            List<int> ids = new List<int>();
            foreach (XLS_Config_Table_UIWindowSetting w in guides)
            {
                if (!ids.Contains(w.id))
                {
                    ids.Add(w.id);
                }
            }
            StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(ids.ToArray(), (sets, pars) =>
            {
                mGuideWindow = sets[0];
                mGuideWindow.CloseWindow();
            });
        }
        #endregion

        #region 初始化引导数据
        List<XLS_Config_Table_UserGuideConfig> triggers = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_UserGuideConfig>();
        if (triggers != null && triggers.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideConfig t in triggers)
            {
                if (!mGuideConfigMaping.ContainsKey(t.id))
                {
                    mGuideConfigMaping.Add(t.id, t);
                }
                if (!mWaitTriggerGuides.Contains(t.id))
                {
                    mWaitTriggerGuides.Add(t.id);
                }
            }
        }
        #endregion
    }
    #endregion

    #region OnDispose
    /// <summary>
    /// OnDispose
    /// </summary>
    protected override void OnDispose()
    {
        mGuideTriggerMaping.Clear();
        mGuideValidateMaping.Clear();
        base.OnDispose();
    }
    #endregion

    #region FilterGuide 过滤引导
    /// <summary>
    /// 过滤引导
    /// </summary>
    /// <param name="_excludeFilterIds">要排除的过滤id组</param>
    public void FilterGuide(params int[] _excludeFilterIds)
    {
        if (_excludeFilterIds != null && _excludeFilterIds.Length > 0)
        {
            foreach (int id in _excludeFilterIds)
            {
                mWaitTriggerGuides.Remove(id);
            }
        }
    }
    #endregion

    #region RegisterGuide 注册引导
    /// <summary>
    /// 引导触发映射
    /// </summary>
    Dictionary<int, List<UIGuideTrigger>> mGuideTriggerMaping = new Dictionary<int, List<UIGuideTrigger>>();
    /// <summary>
    /// 引导验证映射
    /// </summary>
    Dictionary<int, List<UIGuideValidate>> mGuideValidateMaping = new Dictionary<int, List<UIGuideValidate>>();
    /// <summary>
    /// 注册引导
    /// </summary>
    /// <param name="_register">引导注册器</param>
    public void RegisterGuide()
    {
        mGuideWindow.gameObject.SetActive(true);
    }
    #endregion

    #region TriggerCheck 触发检测
    /// <summary>
    /// 当前运行的引导
    /// </summary>
    XLS_Config_Table_UserGuideConfig mRunningUserGuideTrigger = null;
    /// <summary>
    /// 是否需要触发检测
    /// </summary>
    bool mNeedTriggerCheck = false;
    /// <summary>
    /// TriggerCheck
    /// </summary>
    public void TriggerCheck()
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            
        }
    }
    #endregion
}

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
    Dictionary<int, XLS_Config_Table_UserGuideTrigger> mTriggerConfigMaping = new Dictionary<int, XLS_Config_Table_UserGuideTrigger>();
    /// <summary>
    /// 验证配置映射
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideValidate> mValidateConfigMaping = new Dictionary<int, XLS_Config_Table_UserGuideValidate>();
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
        List<XLS_Config_Table_UserGuideTrigger> triggers = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_UserGuideTrigger>();
        if (triggers != null && triggers.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideTrigger t in triggers)
            {
                if (!mTriggerConfigMaping.ContainsKey(t.id))
                {
                    mTriggerConfigMaping.Add(t.id, t);
                }
                if (!mWaitTriggerGuides.Contains(t.id))
                {
                    mWaitTriggerGuides.Add(t.id);
                }
            }
        }

        List<XLS_Config_Table_UserGuideValidate> validates = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_UserGuideValidate>();
        if (validates != null && validates.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideValidate t in validates)
            {
                if (!mValidateConfigMaping.ContainsKey(t.id))
                {
                    mValidateConfigMaping.Add(t.id, t);
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
    public void RegisterGuide(UIGuideRegister _register)
    {
        Transform root = _register.transform;
        if (_register.graphicsNodeIndexs != null && _register.graphicsNodeIndexs.Length > 0)
        {
            foreach (int i in _register.graphicsNodeIndexs)
            {
                root = root.GetChild(i);
            }
        }
        if (_register.isValidate)
        {//如果是等待验证的注册器，则注册验证器
            #region 注册验证               
            if (!mGuideValidateMaping.ContainsKey(_register.validateId))
            {
                UIGuideValidate validate = root.gameObject.AddComponent<UIGuideValidate>();
                validate.SetConfig(mValidateConfigMaping[_register.validateId]);
                if (!mGuideValidateMaping.ContainsKey(_register.validateId))
                {
                    mGuideValidateMaping.Add(_register.validateId, new List<UIGuideValidate>());
                }
                mGuideValidateMaping[_register.validateId].Add(validate);
            }
            #endregion
        }
        else if (mWaitTriggerGuides.Contains(_register.triggerId))
        {//如果是等待触发的注册器，则注册触发器
            #region 注册触发器
            if (mTriggerConfigMaping.ContainsKey(_register.triggerId))
            {
                UIGuideTrigger trigger = root.gameObject.AddComponent<UIGuideTrigger>();
                trigger.SetConfig(mTriggerConfigMaping[_register.triggerId], _register.validateIsFinishEventTriggerType);
                trigger.OnEventTrigger += Trigger_OnEventTrigger;
                if (!mGuideTriggerMaping.ContainsKey(_register.triggerId))
                {
                    mGuideTriggerMaping.Add(_register.triggerId, new List<UIGuideTrigger>());
                }
                mGuideTriggerMaping[_register.triggerId].Add(trigger);
                TriggerCheck();
            }
            else
            {
                Debug.LogErrorFormat("Can't found triggerId 【{0}】", _register.triggerId);
            }
            #endregion
        }
    }
    #endregion

    #region TriggerCheck 触发检测
    /// <summary>
    /// 当前运行的引导
    /// </summary>
    XLS_Config_Table_UserGuideTrigger mRunningUserGuideTrigger = null;
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
            if (mGuideWindow != null)
            {
                OnTriggerCheck();
            }
            else
            {
                mNeedTriggerCheck = true;
            }
        }
    }

    /// <summary>
    /// 触发检测
    /// </summary>
    void OnTriggerCheck()
    {
        mNeedTriggerCheck = false;
        bool isTrigger = false;
        if (mRunningUserGuideTrigger == null && mWaitTriggerGuides.Count > 0)
        {
            foreach (int key in mWaitTriggerGuides)
            {
                if (OnIsTrigger(mTriggerConfigMaping[key]))
                {
                    mRunningUserGuideTrigger = mTriggerConfigMaping[key];
                    isTrigger = true;
                    break;
                }
            }
        }
        if (isTrigger)
        {
            OnDisplayGuideWindow(mRunningUserGuideTrigger);
        }
        else if (mRunningUserGuideTrigger != null)
        {
            switch (mRunningUserGuideTrigger.triggerGuideType)
            {
                case enGuideTriggerType.Weakness:
                    OnDisplayGuideWindow(null);
                    break;
                case enGuideTriggerType.Strong:
                    OnDisplayGuideWindow(mRunningUserGuideTrigger);
                    break;
            }
        }
        else
        {
            OnDisplayGuideWindow(null);
        }
    }
    #endregion

    #region Update
    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (mGuideWindow != null && mNeedTriggerCheck)
        {
            OnTriggerCheck();
        }
    }
    #endregion

    #region OnDisplayGuideWindow 显示引导窗口
    /// <summary>
    /// 显示引导窗口
    /// </summary>
    /// <param name="_guideTrigger">引导触发配置</param>
    void OnDisplayGuideWindow(XLS_Config_Table_UserGuideTrigger _guideTrigger)
    {
        if (_guideTrigger != null)
        {
            if (mGuideTriggerMaping.ContainsKey(_guideTrigger.id))
            {
                mGuideWindow.AddTrigger(mGuideTriggerMaping[_guideTrigger.id].ToArray());
                foreach (UIGuideTrigger t in mGuideTriggerMaping[_guideTrigger.id])
                {
                    t.ToggleTriggerValidate(true);
                }
                mGuideWindow.ToggleActive(_guideTrigger.triggerDisplayType != enGuideDisplayType.HideWindow);
                mGuideWindow.ToggleBackgroundDisplay(_guideTrigger.triggerDisplayType != enGuideDisplayType.HideBackground);
            }
        }
        else
        {
            mGuideWindow.ClearTrigger();
            mGuideWindow.ToggleActive(false);
        }
    }
    #endregion

    #region OnIsTrigger 是否触发引导
    /// <summary>
    /// 是否触发引导
    /// </summary>
    /// <param name="_cfg">配置</param>
    /// <returns>true:触发引导,false:不触发引导</returns>
    bool OnIsTrigger(XLS_Config_Table_UserGuideTrigger _cfg)
    {
        bool? isTrigger = true;
        if (_cfg.levelId > 0)
        {
            if (OnIsLevel != null)
            {
                isTrigger &= OnIsLevel.Invoke(_cfg.levelId);
            }
        }

        for (int i = 0; i < _cfg.triggerCondition.Count; i++)
        {
            switch (_cfg.triggerCondition[i])
            {
                case enGuideTriggerCondition.None:
                    isTrigger &= true;
                    break;
                case enGuideTriggerCondition.SpecifyWindow:
                    isTrigger &= OnWindowIsOpened(_cfg.intValues[i]);
                    break;
                default:
                    isTrigger &= false;
                    break;
            }
        }
        return isTrigger.Value;
    }
    #endregion

    #region Trigger_OnEventTrigger 事件触发
    /// <summary>
    /// 事件触发
    /// </summary>
    /// <param name="_guideTrigger">引导触发器</param>
    /// <param name="_eventTriggerType">触发事件</param>
    /// <param name="_eventData">事件数据</param>
    void Trigger_OnEventTrigger(UIGuideTrigger _guideTrigger, EventTriggerType _eventTriggerType, BaseEventData _eventData)
    {
        if (OnIsEnd(_guideTrigger, _eventTriggerType, _eventData))
        {
            OnMoveNext(_guideTrigger);
        }
    }
    #endregion

    #region OnIsEnd 是否结束引导
    /// <summary>
    /// 是否结束引导
    /// </summary>
    /// <param name="_guideWidget">引导控件</param>    
    /// <param name="_eventTriggerType">触发事件类别</param>
    /// <param name="_eventData">事件参数</param>
    bool OnIsEnd(UIGuideTrigger _guideWidget, EventTriggerType _eventTriggerType, BaseEventData _eventData)
    {
        bool isEnd = true;
        Vector2 point = Vector2.zero;
        if (_guideWidget.config.validateId > 0)
        {
            isEnd = mValidateConfigMaping.ContainsKey(_guideWidget.config.validateId);
            if (isEnd)
            {
                XLS_Config_Table_UserGuideValidate vfg = mValidateConfigMaping[_guideWidget.config.validateId];
                foreach (enGuideValidateCondition c in vfg.validateCondition)
                {
                    switch (c)
                    {
                        case enGuideValidateCondition.None:
                            isEnd &= true;
                            break;
                        case enGuideValidateCondition.Anchor2DPosition:
                            //如果是锚点，则检测已注册的验证器  
                            if (mGuideValidateMaping.ContainsKey(_guideWidget.config.validateId) && mGuideValidateMaping[_guideWidget.config.validateId].Count > 0)
                            {
                                foreach (UIGuideValidate gv in mGuideValidateMaping[_guideWidget.config.validateId])
                                {
                                    isEnd &= _guideWidget.maskGraphic.IsCenterPointInRectanle(gv.maskGraphic, out point);
                                }
                            }
                            else
                            {
                                isEnd &= false;
                            }
                            break;
                    }
                }
            }
            else
            {
                Debug.LogErrorFormat("Can't found validate data 【{0}】", _guideWidget.config.validateId);
            }
        }
        return isEnd;
    }
    #endregion

    #region OnMoveNext 移动到下一个引导
    /// <summary>
    /// 移动到下一个引导
    /// </summary>
    /// <param name="_guideTrigger">触发器</param>
    void OnMoveNext(UIGuideTrigger _guideTrigger)
    {
        mGuideWindow.RemoveTrigger(mGuideTriggerMaping[_guideTrigger.config.id].ToArray());
        mWaitTriggerGuides.Remove(_guideTrigger.config.id);
        foreach (UIGuideTrigger t in mGuideTriggerMaping[_guideTrigger.config.id])
        {
            if (OnTriggerFinished != null)
            {
                OnTriggerFinished.Invoke(t);
            }
            Destroy(t);
        }
        mGuideTriggerMaping.Remove(_guideTrigger.config.id);
        int nextId = _guideTrigger.config.nextId;
        mRunningUserGuideTrigger = mWaitTriggerGuides.Contains(nextId) ? mTriggerConfigMaping[nextId] : null;
        TriggerCheck();
    }
    #endregion
}

using System;
using System.Collections.Generic;
/// <summary>
/// 运行时管理器
/// </summary>
public class StrayFogGameManager : AbsSingleMonoBehaviour
{
    #region Initialization 初始化
    /// <summary>
    /// 是否已初始化
    /// </summary>
    bool m_isInitialized = false;
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="_onCallback">结束回调</param>
    public void Initialization(Action _onCallback)
    {
        if (!m_isInitialized)
        {
            m_isInitialized = true;
            List<Table_GameSetting> settings = SQLiteEntityHelper.Select<Table_GameSetting>();
            runningSetting = settings[0];
            StrayFogGamePools.runningApplication.OnRegisterGuide += Current_OnRegisterGuide;
            StrayFogGamePools.guideManager.OnIsLevel += Current_OnIsLevel;
            StrayFogGamePools.guideManager.OnWindowIsOpened += Current_OnWindowIsOpened;
            StrayFogGamePools.guideManager.OnTriggerFinished += Current_OnTriggerFinished;
            StrayFogGamePools.guideManager.TriggerCheck();
        }

        if (_onCallback != null)
        {
            _onCallback.Invoke();
        }
    }
    #endregion

    #region runningSetting 游戏运行时设定
    /// <summary>
    /// 游戏运行时设定
    /// </summary>
    public Table_GameSetting runningSetting { get; private set; }
    #endregion

    #region 引导相关事件
    /// <summary>
    /// 指定窗口是否打开
    /// </summary>
    /// <param name="_windowId">窗口id</param>
    /// <returns>true:打开,false:未打开</returns>
    bool Current_OnWindowIsOpened(int _windowId)
    {
        return StrayFogGamePools.uiWindowManager.IsOpenedWindow(_windowId);
    }

    /// <summary>
    /// 是否是指定关卡
    /// </summary>
    /// <param name="_levelId">关卡id</param>
    /// <returns>true:是,false:否</returns>
    bool Current_OnIsLevel(int _levelId)
    {
        return true;
    }

    /// <summary>
    /// 注册引导
    /// </summary>
    /// <param name="_guide">引导</param>
    void Current_OnRegisterGuide(UIGuideRegister _guide)
    {
        StrayFogGamePools.guideManager.RegisterGuide(_guide);
    }

    /// <summary>
    /// 触发器完成
    /// </summary>
    /// <param name="_trigger">触发器</param>
    void Current_OnTriggerFinished(UIGuideTrigger _trigger)
    {

    }
    #endregion
}
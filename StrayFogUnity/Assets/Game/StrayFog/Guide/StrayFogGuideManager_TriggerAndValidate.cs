using System.Collections.Generic;
/// <summary>
/// 引导管理器【触发和验证】
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 当前触发的引导
    /// </summary>
    AbsGuideCommand mTriggerGuideCommand = null;
    /// <summary>
    /// 已缓存的窗口
    /// </summary>
    List<AbsUIWindowView> mCacheWindows = new List<AbsUIWindowView>();
    
    #region OpenWindow 打开窗口
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <param name="_windows">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindow(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (_windows != null)
        {
            foreach (AbsUIWindowView w in _windows)
            {
                if (w.config.id != guideWindowId && !mCacheWindows.Contains(w))
                {
                    mCacheWindows.Add(w);
                }
            }
            OnCheckGuideForWindow(_parameters);
        }
    }
    #endregion

    #region CloseWindow 关闭窗口
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_windows">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void CloseWindow(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (_windows != null)
        {
            foreach (AbsUIWindowView w in _windows)
            {
                if (w.config.id != guideWindowId)
                {
                    mCacheWindows.Remove(w);
                }
            }
            OnCheckGuideForWindow(_parameters);
        }
    }
    #endregion


    #region OnCheckTrigger 检测触发
    /// <summary>
    /// 检测触发
    /// </summary>
    /// <param name="_parameters">参数组</param>
    void OnCheckGuideForWindow(params object[] _parameters)
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            if (mCacheWindows != null)
            {
                if (mTriggerGuideCommand == null)
                {
                    foreach (AbsGuideCommand cmd in mWaitGuideCommandMaping.Values)
                    {
                        if (OnIsMatchCondition(cmd, enUserGuideReferObject_ReferType.Refer2D))
                        {                           
                            if (cmd.isMatchCondition(mCacheWindows.ToArray()))
                            {
                                mTriggerGuideCommand = cmd;
                                mTriggerGuideCommand.Excute();
                            }                            
                            break;
                        }
                    }
                }
                else if (OnIsMatchCondition(mTriggerGuideCommand, enUserGuideReferObject_ReferType.Refer2D))
                {                    
                    if (mTriggerGuideCommand.isMatchCondition(mCacheWindows.ToArray()))
                    {
                        mTriggerGuideCommand.Excute();
                    }                    
                }
            }
        }
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_cmd">命令</param>
    /// <param name="_referType">对象参考类型</param>
    /// <returns>true:满足,false:不满足</returns>
    bool OnIsMatchCondition(AbsGuideCommand _cmd, enUserGuideReferObject_ReferType _referType)
    {
        bool result = _cmd != null;
        if (result)
        {
            result &= (_cmd.referType & _referType) == _referType;
            if (_cmd.guideConfig.levelId > 0)
            {
                result &= OnIsLevel(_cmd.guideConfig.levelId);
            }
        }        
        return result;
    }
    #endregion    
}

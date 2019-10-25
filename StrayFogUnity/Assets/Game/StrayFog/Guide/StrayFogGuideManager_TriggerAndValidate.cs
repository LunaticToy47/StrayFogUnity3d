/// <summary>
/// 引导管理器【触发和验证】
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 当前触发的引导
    /// </summary>
    AbsGuideCommand mTriggerGuideCommand = null;

    #region OpenWindowCheckTrigger 打开窗口检测触发
    /// <summary>
    /// 打开窗口检测触发
    /// </summary>
    /// <param name="_windows">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindowCheckTrigger(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            if (_windows != null)
            {
                if (mTriggerGuideCommand == null)
                {
                    foreach (AbsGuideCommand cmd in mWaitGuideCommandMaping.Values)
                    {
                        if ((cmd.referType & enUserGuideReferObject_ReferType.Refer2D) == enUserGuideReferObject_ReferType.Refer2D
                            && cmd.isMatchCondition(cmd, cmd, _windows))
                        {
                            mTriggerGuideCommand = cmd;
                            break;
                        }
                    }
                    if (mTriggerGuideCommand != null)
                    {
                        StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(guideWindowId, (wins, pars) =>
                        {
                            mTriggerGuideCommand.Excute(mTriggerGuideCommand, mTriggerGuideCommand, wins);
                            UnityEngine.Debug.Log("GuideStatus=>" + mTriggerGuideCommand.status);
                        });
                    }
                }
            }
        }
    }
    #endregion

    #region OpenWindowCheckValidate 打开窗口检测验证
    /// <summary>
    /// 打开窗口检测验证
    /// </summary>
    /// <param name="_windows">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindowCheckValidate(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            if (_windows != null && mTriggerGuideCommand != null)
            {
                if (mTriggerGuideCommand.isMatchCondition(mTriggerGuideCommand, mTriggerGuideCommand, _parameters))
                {

                }
            }
        }
    }
    #endregion
}

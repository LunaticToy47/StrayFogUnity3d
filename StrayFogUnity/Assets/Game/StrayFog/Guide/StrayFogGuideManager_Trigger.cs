/// <summary>
/// 引导管理器【触发相关】
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 当前触发的引导
    /// </summary>
    AbsGuideCommand mTriggerGuideCommand = null;

    #region OnOpenWindowCheck 打开窗口检测
    /// <summary>
    /// 打开窗口检测
    /// </summary>
    /// <param name="_windows">窗口</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindowCheck(AbsUIWindowView[] _windows, params object[] _parameters)
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
                            && cmd.isMatchCondition(cmd.status, _windows))
                        {
                            mTriggerGuideCommand = cmd;
                            break;
                        }
                    }
                    if (mTriggerGuideCommand != null)
                    {
                        StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(mGuideWindowId, (wins, pars) =>
                        {
                            mTriggerGuideCommand.Excute(mTriggerGuideCommand.status, wins);
                        });
                    }
                }                
            }
        }
    }
    #endregion
}

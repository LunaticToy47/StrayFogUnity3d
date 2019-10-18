/// <summary>
/// 引导管理器【2D引导】
/// </summary>
public partial class StrayFogGuideManager
{
    #region OnOpenWindowCheck 打开窗口检测
    /// <summary>
    /// 当前运行的引导
    /// </summary>
    XLS_Config_Table_UserGuideConfig mRunningUserGuideTrigger = null;
    /// <summary>
    /// 打开窗口检测
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindowCheck(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(mGuideWindowId, (wins, pars) =>
            {

            });
        }
    }
    #endregion
}

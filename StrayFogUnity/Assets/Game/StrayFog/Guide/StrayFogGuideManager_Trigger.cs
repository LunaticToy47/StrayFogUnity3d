using System;
using System.Collections.Generic;
/// <summary>
/// 引导管理器【触发相关】
/// </summary>
public partial class StrayFogGuideManager
{
    #region OnOpenWindowCheck 打开窗口检测
    /// <summary>
    /// 打开窗口检测
    /// </summary>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public void OpenWindowCheck(AbsUIWindowView[] _windows, params object[] _parameters)
    {
        if (StrayFogGamePools.gameManager.runningSetting.isRunGuide)
        {
            if (_windows != null)
            {
                foreach (XLS_Config_Table_UserGuideConfig cfg in mWaitGuideConfigMaping.Values)
                {
                    IGuideCommand cmd = OnCreateGuideCommand(cfg);
                }
            }
            //StrayFogGamePools.uiWindowManager.OpenWindow<AbsUIGuideWindowView>(mGuideWindowId, (wins, pars) =>
            //{
                
            //});
        }
    }
    #endregion
}

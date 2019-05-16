using System;
using System.Collections.Generic;
/// <summary>
/// UI窗口管理器【场景切换】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region BeforeToggleScene 切换场景前
    /// <summary>
    /// 切换场景前
    /// </summary>
    public void BeforeToggleScene()
    {
        OnGetWindowSerialize().SaveToggleSceneWindowSequence();
        //将当前所有可以关闭的窗口都关闭
        foreach (UIWindowHolder holder in mWindowHolderMaping.Values)
        {
            if (!holder.winCfg.isManualCloseWhenGotoScene)
            {
                holder.SetTargetActive(false);
                holder.ToggleActive();
#if DEBUGLOG
                UnityEngine.Debug.Log(holder.winCfg.name);
#endif
            }
        }
    }
    #endregion

    #region AfterToggleScene 切换场景后
    /// <summary>
    /// 切换场景后
    /// </summary>
    /// <param name="_callback">回调</param>
    public void AfterToggleScene(Action _callback)
    {
        List<int> winIds = OnGetWindowSerialize().RestoreToggleSceneWindowSequence();
        if (winIds.Count > 0)
        {
            OpenWindow(winIds.ToArray(),
            (wins, args) =>
            {
                Action callback = (Action)args[0];
                callback();
            }, _callback);
        }
        else
        {
            _callback();
        }
    }
    #endregion
}

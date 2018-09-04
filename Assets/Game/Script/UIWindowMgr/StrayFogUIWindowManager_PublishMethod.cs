using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口管理器【公共函数】
/// </summary>
public partial class StrayFogUIWindowManager
{
    #region event OnChangeWindowActive 变更窗口激活状态事件
    /// <summary>
    /// 变更窗口激活状态事件
    /// </summary>
    public event UIWindowActiveEventHandler OnChangeWindowActive;
    #endregion

    #region GetWindowSettings 获得指定条件的窗口设置
    /// <summary>
    /// 获得指定条件的窗口设置
    /// </summary>
    /// <param name="_condition">条件</param>
    /// <returns>结果</returns>
    public List<View_UIWindowSetting> GetWindowSettings(Func<View_UIWindowSetting, bool> _condition)
    {
        List<View_UIWindowSetting> result = new List<View_UIWindowSetting>();
        foreach (View_UIWindowSetting w in mWindowSettingMaping.Values)
        {
            if (_condition == null || _condition(w))
            {
                result.Add(w);
            }
        }
        return result;
    }
    #endregion

    #region SetWorldSpaceCamera 设置世界空间摄像机    
    /// <summary>
    /// 设置世界空间摄像机
    /// </summary>
    /// <param name="_camera">世界空间摄像机</param>
    public void SetWorldSpaceCamera(Camera _camera)
    {
        OnSetWorldSpaceCamera(_camera);
    }
    #endregion

    #region GetCanvas 获得指定的画布
    /// <summary>
    /// 获得指定的画布
    /// </summary>
    /// <param name="_renderMode">绘制模式</param>
    /// <returns>画布</returns>
    public UICanvas GetCanvas(RenderMode _renderMode)
    {
        return OnGetCanvas(_renderMode);
    }
    #endregion

    #region RestoreWindowSequence 恢复窗口序列
    /// <summary>
    /// 恢复窗口序列
    /// </summary>
    /// <param name="_onComplete">完成回调</param>
    public void RestoreWindowSequence(Action<AbsUIWindowView[]> _onComplete)
    {
        //OnRestoreWindowSequence(_onComplete);
    }
    #endregion

    #region TransitionScene 场景切换
    /// <summary>
    /// 场景切换
    /// </summary>
    public void TransitionScene()
    {
        //OnRecordWindowSequence();
    }
    #endregion
}

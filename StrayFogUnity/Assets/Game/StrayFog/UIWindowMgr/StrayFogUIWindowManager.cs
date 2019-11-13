using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口设定事件
/// </summary>
/// <param name="_settings">窗口设定组</param>
/// <param name="_parameters">参数组</param>
public delegate void UIWindowSettingEventHandler(XLS_Config_Table_UIWindowSetting[] _settings, params object[] _parameters);

/// <summary>
/// 切换窗口激活状态事件
/// </summary>
/// <param name="_window">窗口</param>
/// <param name="_beforeToggleActive">切换前激活状态</param>
/// <param name="_afterToggleActive">切换后激活状态</param>
public delegate void UIWindowToggleActiveEventHandler(AbsUIWindowView _window,bool _beforeToggleActive, bool _afterToggleActive);

/// <summary>
/// UI窗口实体事件
/// </summary>
/// <typeparam name="W">窗口类型</typeparam>
/// <param name="_windows">窗口组</param>
/// <param name="_parameters">参数组</param>
public delegate void UIWindowEntityEventHandler<W>(W[] _windows, params object[] _parameters) where W : AbsUIWindowView;

/// <summary>
/// UI窗口管理器【主体】
/// </summary>
[AddComponentMenu("StrayFog/Game/Manager/StrayFogUIWindowManager")]
public partial class StrayFogUIWindowManager : AbsSingleMonoBehaviour
{
    #region OnAfterConstructor
    /// <summary>
    /// OnAfterConstructor
    /// </summary>
    protected override void OnAfterConstructor()
    {
        OnInitializeCanvasAndCamera();
        OnInitializeSQLite();
        base.OnAfterConstructor();
    }
    #endregion

    #region event OnToggleWindowActive 切换窗口激活状态事件
    /// <summary>
    /// 切换窗口激活状态事件
    /// </summary>
    public event UIWindowToggleActiveEventHandler OnToggleWindowActive;
    #endregion

    #region GetWindowSettings 获得指定条件的窗口设置
    /// <summary>
    /// 获得指定条件的窗口设置
    /// </summary>
    /// <param name="_condition">条件</param>
    /// <returns>结果</returns>
    public List<XLS_Config_Table_UIWindowSetting> GetWindowSettings(Func<XLS_Config_Table_UIWindowSetting, bool> _condition)
    {
        List<XLS_Config_Table_UIWindowSetting> result = new List<XLS_Config_Table_UIWindowSetting>();
        foreach (XLS_Config_Table_UIWindowSetting w in mWindowSettingMaping.Values)
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
}
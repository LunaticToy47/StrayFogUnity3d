#if UNITY_EDITOR
using System;
using UnityEditor;
#endif
using UnityEngine;
/// <summary>
/// 窗口是否有实例句柄
/// </summary>
/// <typeparam name="W">窗口类型</typeparam>
/// <param name="_winCfg">窗口配置</param>
/// <param name="_winType">窗口类型</param>
/// <returns>true:有实例,false:无实例</returns>
public delegate bool UIWindowHasInstanceEventHandle<W>(XLS_Config_Table_UIWindowSetting _winCfg) where W : AbsUIWindowView;

/// <summary>
/// 检测窗口实例化是否完成句柄
/// </summary>
/// <typeparam name="W">窗口类型</typeparam>
/// <param name="_winCfgs">窗口配置</param>
/// <param name="_callback">回调</param>
/// <param name="_parameters">参数</param>
public delegate void UIWindowCheckInstanceCompleteEventHandle<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters) where W : AbsUIWindowView;

/// <summary>
/// 窗口实例检测
/// </summary>
[AddComponentMenu("Game/UI/UIWindowCheckInstance")]
public class UIWindowCheckInstance : AbsMonoBehaviour
{
#if UNITY_EDITOR
    [InvokeMethod("EditorDisplayParameter")]
    [AliasTooltip("调用函数")]
    public int invokeMethod;
    /// <summary>
    /// OnDisplayPath
    /// </summary>
    /// <param name="_position">位置</param>
    /// <param name="_property">属性</param>
    /// <param name="_label">标签</param>
    /// <returns>高度</returns>
    protected float EditorDisplayParameter(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        float y = _position.y;
        _position.height = 16;
        EditorGUI.LabelField(_position, "isRunCheck=>" + isRunCheck);
        _position.y += _position.height;
        return _position.y - y;
    }
#endif

    /// <summary>
    /// 是否在运行检测
    /// </summary>
    [AliasTooltip("是否在运行检测")]
    public bool isRunCheck { get; private set; }
    
    /// <summary>
    /// 名称前缀
    /// </summary>
    static readonly string mNamePrefix = typeof(UIWindowCheckInstance).Name;
    /// <summary>
    /// 完成回调
    /// </summary>
    Action mCompleteCallback;
    /// <summary>
    /// 是否有实例回调
    /// </summary>
    Func<XLS_Config_Table_UIWindowSetting, bool> mHasInstanceCallback;
    /// <summary>
    /// 窗口配置
    /// </summary>
    XLS_Config_Table_UIWindowSetting[] mWinCfgs;
    /// <summary>
    /// 是否都完成
    /// </summary>
    bool mIsAllTrue = false;
    /// <summary>
    /// 检测窗口实例化是否完成
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_hasInstanceCallback">是否有实例回调</param>
    /// <param name="_completeCallback">完成回调</param>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    public void CheckInstanceLoadComplete<W>(
        UIWindowHasInstanceEventHandle<W> _hasInstanceCallback,
        UIWindowCheckInstanceCompleteEventHandle<W> _completeCallback, 
        XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, 
        params object[] _parameters)
        where W : AbsUIWindowView
    {        
        mWinCfgs = _winCfgs;        
        mHasInstanceCallback = (XLS_Config_Table_UIWindowSetting cfg) => { return _hasInstanceCallback(cfg); };
        mCompleteCallback = () => { _completeCallback(_winCfgs, _callback, _parameters); };
        isRunCheck = true;
        gameObject.SetActive(true);
        OnResetName();
    }

    /// <summary>
    /// 重置名称
    /// </summary>
    void OnResetName()
    {
#if UNITY_EDITOR
        gameObject.name = string.Format("{0}【isRunCheck:{1}】", mNamePrefix, isRunCheck);
#endif     
    }

    /// <summary>
    /// 停止
    /// </summary>
    void OnStop()
    {
        isRunCheck = false;
        mWinCfgs = null;
        mHasInstanceCallback = null;
        mCompleteCallback =null;
        OnResetName();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// LateUpdate
    /// </summary>
    void LateUpdate()
    {
        if (isRunCheck)
        {
            if (mWinCfgs != null && mWinCfgs.Length > 0)
            {
                mIsAllTrue = true;
                foreach (XLS_Config_Table_UIWindowSetting cfg in mWinCfgs)
                {
                    mIsAllTrue &= mHasInstanceCallback(cfg);
                }
                if (mIsAllTrue)
                {                    
                    mCompleteCallback();
                    OnStop();
                }
            }
            else
            {
                isRunCheck = false;
            }
        }        
    }
}
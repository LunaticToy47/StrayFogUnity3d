using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口管理器【加载窗口到内存】
/// </summary>
public partial class StrayFogUIWindowManager 
{
    #region OnLoadWindowInMemory 加载窗口到内存
    /// <summary>
    /// 加载窗口到内存
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_isInstance">是否实例化窗口</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数组</param>
    void OnLoadWindowInMemory(XLS_Config_Table_UIWindowSetting[] _winCfgs,bool _isInstance, UIWindowSettingEventHandler _callback, params object[] _parameters)
    {
        int index = 0;
        Dictionary<int, AssetBundleResult> resultMaping = new Dictionary<int, AssetBundleResult>();
        int count = _winCfgs.Length;
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {            
            StrayFogGamePools.assetBundleManager.LoadAssetInMemory(cfg.fileId, cfg.folderId,
            (result) =>
            {
                index++;
                bool isInstance = (bool)result.extraParameter[0];
                if (isInstance)
                {
                    XLS_Config_Table_UIWindowSetting winCfg = (XLS_Config_Table_UIWindowSetting)result.extraParameter[1];
                    Dictionary<int, AssetBundleResult> winMemory = (Dictionary<int, AssetBundleResult>)result.extraParameter[2];
                    if (!winMemory.ContainsKey(winCfg.id))
                    {
                        winMemory.Add(winCfg.id, result);
                    }
                    else
                    {
                        winMemory[winCfg.id] = result;
                    }
                    if (index >= count)
                    {
                        XLS_Config_Table_UIWindowSetting[] cfgs = (XLS_Config_Table_UIWindowSetting[])result.extraParameter[3];
                        UIWindowSettingEventHandler callback = (UIWindowSettingEventHandler)result.extraParameter[4];
                        object[] extralParameter = (object[])result.extraParameter[5];
                        callback(cfgs, winMemory,extralParameter);
                    }
                }
                else if (index >= count)
                {
                    XLS_Config_Table_UIWindowSetting[] cfgs = (XLS_Config_Table_UIWindowSetting[])result.extraParameter[3];
                    UIWindowSettingEventHandler callback = (UIWindowSettingEventHandler)result.extraParameter[4];
                    object[] extralParameter = (object[])result.extraParameter[5];
                    callback(cfgs, extralParameter);
                }
            }, _isInstance, cfg, resultMaping,_winCfgs, _callback, _parameters);
        }
    }
    #endregion

    #region OnOpenWindow 打开窗口
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OnOpenWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {        
        OnLoadWindowInMemory(_winCfgs, true, (cfgs, args) =>
        {
            Dictionary<int, AssetBundleResult> memoryAssetResult = (Dictionary<int, AssetBundleResult>)args[0];
            object[] memoryArgs = (object[])args[1];
            UIWindowEntityEventHandler<W> call = (UIWindowEntityEventHandler<W>)memoryArgs[0];
            object[] extArgs = (object[])memoryArgs[1];
            OnInstanceWindow(cfgs, memoryAssetResult, call, extArgs);
        }, _callback, _parameters);
    }

    /// <summary>
    /// 实例化窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_memoryAssetResult">内存结果</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    void OnInstanceWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, Dictionary<int, AssetBundleResult> _memoryAssetResult, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {

    }
    #endregion

    #region OnCloseWindow 关闭窗口
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OnCloseWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {

    }
    #endregion

    #region OnGetWindow 获得窗口
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数组</param>
    public void OnGetWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {

    }
    #endregion

    #region OnIsExistsWindow 窗口是否存在
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    /// <returns>true:存在,false:不存在</returns>
    public bool OnIsExistsWindow(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        return false;
    }
    #endregion

    #region OnIsOpenedWindow 窗口是否打开
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    /// <returns>true:打开,false:关闭</returns>
    public bool OnIsOpenedWindow(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        return false;
    }
    #endregion    
}
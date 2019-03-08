using System;
using System.Collections.Generic;
using System.Reflection;
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
            OnInstanceWindow(cfgs,memoryAssetResult, call, extArgs);
        }, _callback, _parameters);
    }

    /// <summary>
    /// 已实例化的窗口映射
    /// </summary>
    Dictionary<int, AbsUIWindowView> mInstanceWindowMaping = new Dictionary<int, AbsUIWindowView>();
    /// <summary>
    /// 窗口实体SiblingIndex缓存
    /// </summary>
    Dictionary<int, GameObject> mInstanceCacheSiblingIndexMaping = new Dictionary<int, GameObject>();

    /// <summary>
    /// 设置窗口SiblingIndex缓存
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    void OnSetInstanceCacheSiblingIndex(XLS_Config_Table_UIWindowSetting _winCfg)
    {
        UIWindowSiblingIndex root = OnGetCacheSiblingIndexRoot((RenderMode)_winCfg.renderMode);
        Transform holder = root.GetWindowSiblingIndex(_winCfg);
        if (!mInstanceCacheSiblingIndexMaping.ContainsKey(_winCfg.id))
        {
            GameObject go = new GameObject(_winCfg.name+ "【SiblingIndex】");
            go.transform.SetParent(holder);
            DontDestroyOnLoad(go);
            mInstanceCacheSiblingIndexMaping.Add(_winCfg.id, go);
        }
        mInstanceCacheSiblingIndexMaping[_winCfg.id].transform.SetAsLastSibling();
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
        foreach (KeyValuePair<int, AssetBundleResult> key in _memoryAssetResult)
        {
            XLS_Config_Table_UIWindowSetting cacheCfg = (XLS_Config_Table_UIWindowSetting)key.Value.extraParameter[1];
            OnSetInstanceCacheSiblingIndex(cacheCfg);
            if (!mInstanceWindowMaping.ContainsKey(key.Key))
            {
                mInstanceWindowMaping.Add(key.Key, null);
                key.Value.Instantiate<GameObject>(false, (win, args) =>
                {
                    XLS_Config_Table_UIWindowSetting winCfg = (XLS_Config_Table_UIWindowSetting)args[0];
                    GameObject prefab = win;
                    if (prefab != null)
                    {
                        prefab.name = winCfg.name + "[" + winCfg.id + "]";
                        Type type = Assembly.GetCallingAssembly().GetType(winCfg.name);
                        W window = (W)prefab.AddComponent(type);
                        window.SetConfig(winCfg);
                        OnGetCanvas((RenderMode)winCfg.renderMode).AttachWindow(window);
                        //window.rectTransform.SetSiblingIndex(mWindowLayerSiblingIndex[(int)config.layer][config.id]);
                        mInstanceWindowMaping[winCfg.id] = window;
                    }
                    OnCheckInstanceLoadComplete<W>((XLS_Config_Table_UIWindowSetting[])args[1], (UIWindowEntityEventHandler<W>)args[2], (object[])args[3]);                   
                }, cacheCfg, _winCfgs, _callback, _parameters);
            }
            else
            {
                OnCheckInstanceLoadComplete<W>(_winCfgs, _callback, _parameters);
            }
        }
    }

    /// <summary>
    /// 检测窗口实例化是否完成
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    void OnCheckInstanceLoadComplete<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        bool isChecked = mInstanceWindowMaping.Count >= _winCfgs.Length;
        if (isChecked)
        {//当实体窗口>=要加载的窗口时，才检测是否所有的窗口都已实例化
            foreach(XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
                isChecked &= mInstanceWindowMaping.ContainsKey(cfg.id) && 
                    mInstanceWindowMaping[cfg.id] is W;
            }
        }

        if (isChecked)
        {
            Debug.Log(_winCfgs.Length + " " + _callback + " " + _parameters.JsonSerialize());
        }
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
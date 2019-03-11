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

    #region OnSettingWindowSerialize 设置窗口序列化
    /// <summary>
    /// 设置窗口序列化
    /// </summary>
    /// <param name="_serializeId">序列ID</param>
    /// <param name="_winCfg">窗口配置</param>
    void OnSettingWindowSerialize(int _serializeId, XLS_Config_Table_UIWindowSetting _winCfg)
    {
        
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
    /// 窗口占位符
    /// </summary>
    Dictionary<int, UIWindowHolder> mWindowHolderMaping = new Dictionary<int, UIWindowHolder>();

    /// <summary>
    /// 创建窗口占位符
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    void OnCreateWindowHolder(XLS_Config_Table_UIWindowSetting _winCfg)
    {
        UISiblingIndexCanvas canvas = OnGetSiblingIndexCanvas((RenderMode)_winCfg.renderMode);
        RectTransform root = canvas.CreateWindowSiblingIndexHolder(_winCfg);
        if (!mWindowHolderMaping.ContainsKey(_winCfg.id))
        {
            GameObject go = new GameObject(_winCfg.name+ "【Holder】");
            go.transform.SetParent(root);
            DontDestroyOnLoad(go);
            UIWindowHolder wh = go.AddComponent<UIWindowHolder>();
            wh.SetWindowConfig(_winCfg);
            wh.SetWindowCanvas(OnGetCanvas((RenderMode)_winCfg.renderMode));
            mWindowHolderMaping.Add(_winCfg.id, wh);
        }
        mWindowHolderMaping[_winCfg.id].transform.SetAsLastSibling();
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
        int serializeId = Guid.NewGuid().ToString().UniqueHashCode();
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            OnCreateWindowHolder(cfg);
            OnSettingWindowSerialize(serializeId,cfg);
            if (!mWindowHolderMaping[cfg.id].isMarkLoadedWindowInstace)
            {
                mWindowHolderMaping[cfg.id].MarkLoadedWindowInstace();
                _memoryAssetResult[cfg.id].Instantiate<GameObject>(false, (win, args) =>
                {
                    XLS_Config_Table_UIWindowSetting winCfg = (XLS_Config_Table_UIWindowSetting)args[0];
                    GameObject prefab = win;
                    if (prefab != null)
                    {
                        prefab.name = winCfg.name + "[" + winCfg.id + "]";
                        Type type = Assembly.GetCallingAssembly().GetType(winCfg.name);
                        W window = (W)prefab.AddComponent(type);
                        window.SetConfig(winCfg);
                        window.OnCloseWindow += Window_OnCloseWindow;
                        mWindowHolderMaping[winCfg.id].SetWindow(window);
                    }
                    OnCheckInstanceLoadComplete<W>((XLS_Config_Table_UIWindowSetting[])args[1], (UIWindowEntityEventHandler<W>)args[2], (object[])args[3]);
                }, cfg, _winCfgs, _callback, _parameters);
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
        bool isChecked = mWindowHolderMaping.Count >= _winCfgs.Length;
        if (isChecked)
        {//当实体窗口>=要加载的窗口时，才检测是否所有的窗口都已实例化
            foreach(XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
                isChecked &= mWindowHolderMaping[cfg.id].HasWindowInstance<W>();
            }
        }

        if (isChecked)
        {
            List<W> windows = new List<W>();
            foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
                mWindowHolderMaping[cfg.id].ToggleActive(true);
                windows.Add((W)mWindowHolderMaping[cfg.id].window);
            }
            _callback(windows.ToArray(), _parameters);
        }
    }
    #endregion

    #region OnCloseWindow 关闭窗口
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <param name="_window">窗口</param>
    void Window_OnCloseWindow(AbsUIWindowView _window)
    {
        CloseWindow(_window.config.id);
    }

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
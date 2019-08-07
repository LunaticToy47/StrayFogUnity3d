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
    void OnLoadWindowInMemory(XLS_Config_Table_UIWindowSetting[] _winCfgs, bool _isInstance, UIWindowSettingEventHandler _callback, params object[] _parameters)
    {
        Dictionary<int, IAssetBundleOutput> outputMaping = new Dictionary<int, IAssetBundleOutput>();
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            StrayFogGamePools.assetBundleManager.LoadAssetInMemory(cfg.fileId, cfg.folderId,
            (output) =>
            {
                bool isInstance = (bool)output.input.extraParameter[0];
                XLS_Config_Table_UIWindowSetting winCfg = (XLS_Config_Table_UIWindowSetting)output.input.extraParameter[1];
                Dictionary<int, IAssetBundleOutput> winMemory = (Dictionary<int, IAssetBundleOutput>)output.input.extraParameter[2];
                XLS_Config_Table_UIWindowSetting[] cfgs = (XLS_Config_Table_UIWindowSetting[])output.input.extraParameter[3];
                #region 添加内存映射
                if (!winMemory.ContainsKey(winCfg.id))
                {
                    winMemory.Add(winCfg.id, output);
                }
                else
                {
                    winMemory[winCfg.id] = output;
                }
                #endregion

                bool isAllLoad = true;
                #region 是否所有配置窗口已加载到内存
                if (cfgs != null && cfgs.Length > 0)
                {
                    foreach (XLS_Config_Table_UIWindowSetting c in cfgs)
                    {
                        isAllLoad &= winMemory.ContainsKey(c.id);
                    }
                }
                #endregion

                if (isAllLoad)
                {
                    #region 内存加载完成回调
                    if (isInstance)
                    {
                        UIWindowSettingEventHandler callback = (UIWindowSettingEventHandler)output.input.extraParameter[4];
                        object[] extralParameter = (object[])output.input.extraParameter[5];
                        callback(cfgs, winMemory, extralParameter);
                    }
                    else
                    {
                        UIWindowSettingEventHandler callback = (UIWindowSettingEventHandler)output.input.extraParameter[4];
                        object[] extralParameter = (object[])output.input.extraParameter[5];
                        callback(cfgs, extralParameter);
                    }
                    #endregion
                }
            }, _isInstance, cfg, outputMaping, _winCfgs, _callback, _parameters);
        }
    }
    #endregion

    #region OnSettingWindowSerialize 设置窗口序列化
    /// <summary>
    /// 窗口序列
    /// </summary>
    UIWindowSerialize mUIWindowSerialize;
    /// <summary>
    /// 创建窗口序列化
    /// </summary>
    /// <returns>获得窗口序列化</returns>
    UIWindowSerialize OnGetWindowSerialize()
    {
        if (mUIWindowSerialize == null)
        {
            GameObject go = new GameObject("UIWindowSerialize");
            go.transform.SetParent(transform);
            go.hideFlags = hideFlags;
            mUIWindowSerialize = go.AddComponent<UIWindowSerialize>();
            mUIWindowSerialize.OnSearchAllWindowHolders += () => { return mWindowHolderMaping; };
        }
        return mUIWindowSerialize;
    }

    /// <summary>
    /// 设置窗口序列化
    /// </summary>
    /// <param name="_winCfgs">窗口配置组</param>
    void OnSettingWindowSerialize(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        OnGetWindowSerialize().OpenWindowSerialize(_winCfgs);
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
        OnCreateWindowHolder(_winCfgs);
        OnSettingWindowSerialize(_winCfgs);
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            mWindowHolderMaping[cfg.id].SetTargetActive(true);
        }
        OnLoadWindowInMemory(_winCfgs, true, (cfgs, args) =>
        {
            Dictionary<int, IAssetBundleOutput> memoryAssetResult = (Dictionary<int, IAssetBundleOutput>)args[0];
            object[] memoryArgs = (object[])args[1];
            UIWindowEntityEventHandler<W> call = (UIWindowEntityEventHandler<W>)memoryArgs[0];
            object[] extArgs = (object[])memoryArgs[1];
            OnInstanceWindow(cfgs, memoryAssetResult, call, extArgs);
        }, _callback, _parameters);
    }

    /// <summary>
    /// 窗口占位符
    /// </summary>
    Dictionary<int, UIWindowHolder> mWindowHolderMaping = new Dictionary<int, UIWindowHolder>();

    /// <summary>
    /// 创建窗口占位符
    /// </summary>
    /// <param name="_winCfgs">窗口配置组</param>
    void OnCreateWindowHolder(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        if (_winCfgs != null && _winCfgs.Length > 0)
        {
            foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
                UISiblingIndexCanvas canvas = OnGetSiblingIndexCanvas(cfg.winRenderMode);
                RectTransform root = canvas.CreateWindowSiblingIndexHolder(cfg);
                if (!mWindowHolderMaping.ContainsKey(cfg.id))
                {
                    GameObject go = new GameObject(cfg.name + "【Holder】【" + cfg.id + "】");
                    go.transform.SetParent(root);
                    UIWindowHolder wh = go.AddComponent<UIWindowHolder>();
                    wh.SetWindowConfig(cfg);
                    wh.SetWindowCanvas(OnGetCanvas(cfg.winRenderMode));
                    mWindowHolderMaping.Add(cfg.id, wh);
                }
                mWindowHolderMaping[cfg.id].transform.SetAsLastSibling();
            }
        }
    }

    /// <summary>
    /// 实例化窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_memoryAssetResult">内存结果</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    void OnInstanceWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, Dictionary<int, IAssetBundleOutput> _memoryAssetResult, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        OnCheckInstance<W>(_winCfgs, _callback, _parameters);
        //创建实例
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            if (!mWindowHolderMaping[cfg.id].isMarkLoadedWindowInstace)
            {
                mWindowHolderMaping[cfg.id].MarkLoadedWindowInstace();
                _memoryAssetResult[cfg.id].Instantiate<GameObject>(false, (result) =>
                {
                    XLS_Config_Table_UIWindowSetting winCfg = (XLS_Config_Table_UIWindowSetting)result.extraParemeter[0];
                    GameObject prefab = (GameObject)result.asset;
                    if (prefab != null)
                    {
                        prefab.name = winCfg.name + "[" + winCfg.id + "]";
                        Type type = Assembly.GetCallingAssembly().GetType(winCfg.name);
                        W window = default(W);
                        if (type == null)
                        {
                            window = (W)(AbsUIWindowView)prefab.AddComponent<UIXLuaWindow>();
                        }
                        else
                        {
                            window = (W)prefab.AddComponent(type);
                        }
                        window.SetConfig(winCfg);
                        window.OnCloseWindow += Window_OnCloseWindow;
                        mWindowHolderMaping[winCfg.id].SetWindow(window);
                    }
                }, cfg, _winCfgs, _callback, _parameters);
            }
        }
    }

    /// <summary>
    /// 窗口实例检测
    /// </summary>
    List<UIWindowCheckInstance> mUIWindowCheckInstanceMaping = new List<UIWindowCheckInstance>();
    /// <summary>
    /// 检测窗口实例化是否完成
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    void OnCheckInstance<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        bool isRunCheck = false;
        foreach (UIWindowCheckInstance check in mUIWindowCheckInstanceMaping)
        {
            isRunCheck |= !check.isRunCheck;
            if (isRunCheck)
            {
                check.CheckInstanceLoadComplete<W>(OnUIWindowHasInstance<W>, OnCheckInstanceComplete, _winCfgs, _callback, _parameters);
                break;
            }
        }
        if (!isRunCheck)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(transform);
            go.hideFlags = hideFlags;
            UIWindowCheckInstance check = go.AddComponent<UIWindowCheckInstance>();
            check.CheckInstanceLoadComplete<W>(OnUIWindowHasInstance<W>, OnCheckInstanceComplete, _winCfgs, _callback, _parameters);
            mUIWindowCheckInstanceMaping.Add(check);
        }
    }

    /// <summary>
    /// 窗口是否有实例
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    /// <returns>true:有实例,false:无实例</returns>
    bool OnUIWindowHasInstance<W>(XLS_Config_Table_UIWindowSetting _winCfg)
        where W : AbsUIWindowView
    {
        return mWindowHolderMaping[_winCfg.id].HasWindowInstance<W>();
    }

    /// <summary>
    /// 检测窗口实例化是否完成
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_callback">回调</param>
    /// <param name="_parameters">参数</param>
    void OnCheckInstanceComplete<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        List<W> windows = new List<W>();
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            mWindowHolderMaping[cfg.id].ToggleSiblingIndex();
            windows.Add((W)mWindowHolderMaping[cfg.id].window);
        }

        foreach (UIWindowHolder holder in mWindowHolderMaping.Values)
        {
            holder.ToggleActive();
        }
       
        _callback(windows.ToArray(), _parameters);
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
    void OnCloseWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        List<int> closeWinIds = new List<int>();
        Dictionary<int, int> sameLayerLessThenSiblingIndex = new Dictionary<int, int>();
        List<int> lessThenSiblingIndex = new List<int>();

        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            if (mWindowHolderMaping.ContainsKey(cfg.id))
            {
                mWindowHolderMaping[cfg.id].SetTargetActive(false);
                if (!closeWinIds.Contains(cfg.id))
                {
                    closeWinIds.Add(cfg.id);
                }
                #region 统计需要隐藏的各层级的最大SiblingIndex
                switch (cfg.winCloseMode)
                {
                    case enUIWindowCloseMode.WhenCloseHiddenSameLayerAndMoreThanSiblingIndex:
                        if (!sameLayerLessThenSiblingIndex.ContainsKey(cfg.layer))
                        {
                            sameLayerLessThenSiblingIndex.Add(cfg.layer, mWindowHolderMaping[cfg.id].windowSiblingIndex);
                        }
                        else
                        {
                            sameLayerLessThenSiblingIndex[cfg.layer] = Mathf.Max(sameLayerLessThenSiblingIndex[cfg.layer], mWindowHolderMaping[cfg.id].windowSiblingIndex);
                        }
                        break;
                    case enUIWindowCloseMode.WhenCloseHiddenMoreThanSiblingIndex:
                        if (!lessThenSiblingIndex.Contains(mWindowHolderMaping[cfg.id].windowSiblingIndex))
                        {
                            lessThenSiblingIndex.Add(mWindowHolderMaping[cfg.id].windowSiblingIndex);
                        }
                        else
                        {
                            lessThenSiblingIndex[0] = Mathf.Max(lessThenSiblingIndex[0], mWindowHolderMaping[cfg.id].windowSiblingIndex);
                        }
                        break;
                }
                #endregion
            }
        }

        #region 设置要隐藏的窗口ID
        foreach (KeyValuePair<int, UIWindowHolder> holder in mWindowHolderMaping)
        {
            if (
                sameLayerLessThenSiblingIndex.ContainsKey(holder.Value.winCfg.layer)
                && holder.Value.windowSiblingIndex < sameLayerLessThenSiblingIndex[holder.Value.winCfg.layer]
                )
            {
                holder.Value.SetTargetActive(false);
            }
            if (
                lessThenSiblingIndex.Count > 0
                && holder.Value.windowSiblingIndex < lessThenSiblingIndex[0]
                )
            {
                holder.Value.SetTargetActive(false);
            }
        }
        #endregion

        List<int> autoOpenWindows = OnGetWindowSerialize().GetAutoRestoreSequence(closeWinIds);
        foreach (int id in autoOpenWindows)
        {
            if (mWindowHolderMaping.ContainsKey(id))
            {
                mWindowHolderMaping[id].SetTargetActive(true);
            }
        }

        foreach (UIWindowHolder holder in mWindowHolderMaping.Values)
        {
            holder.ToggleActive();
        }
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
    void OnGetWindow<W>(XLS_Config_Table_UIWindowSetting[] _winCfgs, UIWindowEntityEventHandler<W> _callback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        W[] wins = new W[0];
        if (_winCfgs != null && _winCfgs.Length > 0)
        {
            wins = new W[_winCfgs.Length];
            for(int i=0;i< _winCfgs.Length;i++)
            {
                if (mWindowHolderMaping.ContainsKey(_winCfgs[i].id))
                {
                    wins[i] = (W)mWindowHolderMaping[_winCfgs[i].id].window;
                }
            }
        }
        _callback(wins, _parameters);
    }
    #endregion

    #region OnIsExistsWindow 窗口是否存在
    /// <summary>
    /// 窗口是否存在
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    /// <returns>true:存在,false:不存在</returns>
    bool OnIsExistsWindow(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        bool isAllOpened = _winCfgs != null && _winCfgs.Length > 0;
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            isAllOpened &= mWindowHolderMaping.ContainsKey(cfg.id) 
                && mWindowHolderMaping[cfg.id].window != null;
        }
        return isAllOpened;
    }
    #endregion

    #region OnIsOpenedWindow 窗口是否打开
    /// <summary>
    /// 窗口是否打开
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    /// <returns>true:打开,false:关闭</returns>
    bool OnIsOpenedWindow(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        bool isAllOpened = _winCfgs != null && _winCfgs.Length > 0;
        foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
        {
            isAllOpened &= mWindowHolderMaping.ContainsKey(cfg.id) 
                && mWindowHolderMaping[cfg.id].window != null
                && mWindowHolderMaping[cfg.id].window.isActiveAndEnabled;
        }        
        return isAllOpened;
    }
    #endregion    
}
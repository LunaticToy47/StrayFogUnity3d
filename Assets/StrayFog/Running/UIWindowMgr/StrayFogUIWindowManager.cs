using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
    /// <summary>
    /// UI窗口设定事件
    /// </summary>
    /// <param name="_settings">窗口设定组</param>
    /// <param name="_parameters">参数组</param>
    public delegate void UIWindowSettingEventHandler(View_UIWindowSetting[] _settings, params object[] _parameters);

    /// <summary>
    /// UI窗口实体事件
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windows">窗口组</param>
    /// <param name="_parameters">参数组</param>
    public delegate void UIWindowEntityEventHandler<W>(W[] _windows, params object[] _parameters) where W : AbsUIWindowView;

    /// <summary>
    /// 设置窗口激活状态事件
    /// </summary>
    /// <param name="_window">窗口</param>
    /// <param name="_isActive">激活状态</param>
    public delegate void UIWindowActiveEventHandler(AbsUIWindowView _window, bool _isActive);

/// <summary>
/// UI窗口管理器【主体】
/// </summary>
public partial class StrayFogUIWindowManager : AbsSingleMonoBehaviour<StrayFogUIWindowManager>
{
    #region OnLoadWindowInMemory 加载窗口到内存
    /// <summary>
    /// UI窗口加载到内存事件
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfg">窗口配置</param>
    /// <param name="_memoryResult">内存结果</param>
    /// <param name="_configCallback">配置回调</param>
    /// <param name="_windowCallback">窗口回调</param>
    /// <param name="_parameters">参数组</param>
    delegate void UILoadInMemoryEventHandler<W>(View_UIWindowSetting[] _winCfg, Dictionary<int, AssetBundleResult> _memoryResult,
        UIWindowSettingEventHandler _configCallback, UIWindowEntityEventHandler<W> _windowCallback, params object[] _parameters) where W : AbsUIWindowView;
    /// <summary>
    /// 加载窗口到内存
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_winCfgs">窗口配置</param>
    /// <param name="_configCallback">配置回调</param>
    /// <param name="_windowCallback">窗口回调</param>
    /// <param name="_memoryCallback">内存回调</param>
    /// <param name="_parameters">参数组</param>
    void OnLoadWindowInMemory<W>(View_UIWindowSetting[] _winCfgs,
        UIWindowSettingEventHandler _configCallback, UIWindowEntityEventHandler<W> _windowCallback,
        UILoadInMemoryEventHandler<W> _memoryCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        int index = 0;
        Dictionary<int, AssetBundleResult> resultMaping = new Dictionary<int, AssetBundleResult>();
        int count = _winCfgs.Length;

        foreach (View_UIWindowSetting cfg in _winCfgs)
        {
            StrayFogAssetBundleManager.current.LoadAssetInMemory(cfg.fileId, cfg.folderId,
            (result) =>
            {
                index++;
                int winId = OnGetWindowSetting(result.assetDiskMaping.folderId, result.assetDiskMaping.fileId)[0];
                if (!resultMaping.ContainsKey(winId))
                {
                    resultMaping.Add(winId, result);
                }
                else
                {
                    resultMaping[winId] = result;
                }
                if (index >= count)
                {
                    View_UIWindowSetting[] winCfgs = (View_UIWindowSetting[])result.extraParameter[0];
                    UIWindowSettingEventHandler cfgCall = (UIWindowSettingEventHandler)result.extraParameter[1];
                    UIWindowEntityEventHandler<W> winCall = (UIWindowEntityEventHandler<W>)result.extraParameter[2];
                    UILoadInMemoryEventHandler<W> memoryCall = (UILoadInMemoryEventHandler<W>)result.extraParameter[3];
                    object[] pams = (object[])result.extraParameter[4];
                    _memoryCallback(winCfgs, resultMaping, cfgCall, winCall, pams);
                }
            }, _winCfgs, _configCallback, _windowCallback, _memoryCallback, _parameters);
        }
    }
    #endregion

    #region OnPreloadWindow 预加载窗口
    /// <summary>
    /// 预加载窗口到内存
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id</param>
    /// <param name="_cfgCallback">配置回调</param>
    /// <param name="_winCallback">窗口回调</param>
    /// <param name="_memoryCallback">内存回调</param>
    /// <param name="_parameters">参数组</param>
    void OnPreloadWindow<W>(View_UIWindowSetting[] _windowIds,
        UIWindowSettingEventHandler _cfgCallback,
        UIWindowEntityEventHandler<W> _winCallback,
        UILoadInMemoryEventHandler<W> _memoryCallback,
        params object[] _parameters)
    where W : AbsUIWindowView
    {
        if (_memoryCallback == null)
        {
            _memoryCallback = (cfg, result, cfgCall, winCall, pts) =>
            {
                if (cfgCall != null)
                {
                    cfgCall.Invoke(cfg, pts);
                }
            };
        }
        OnLoadWindowInMemory<W>(_windowIds, _cfgCallback, _winCallback, _memoryCallback, _parameters);
    }
    #endregion

    #region OnPresetAdjustWindowSiblingIndex 窗口层级最大SiblingIndex
    /// <summary>
    /// 层级窗口索引
    /// Key:层级
    /// Value:【Key:窗口id,Value:窗口SiblingIndex】
    /// </summary>
    SortedDictionary<int, Dictionary<int, int>> mWindowLayerSiblingIndex = new SortedDictionary<int, Dictionary<int, int>>();
    /// <summary>
    /// 预调整窗口深度
    /// </summary>
    /// <param name="_winCfg">窗口配置</param>
    /// <returns>返回当前窗口配置</returns>
    View_UIWindowSetting OnPresetAdjustWindowSiblingIndex(View_UIWindowSetting _winCfg)
    {
        int siblingIndex = 0;
        int winLayer = (int)_winCfg.layer;
        if (!mWindowLayerSiblingIndex.ContainsKey(winLayer))
        {
            mWindowLayerSiblingIndex.Add(winLayer, new Dictionary<int, int>());
        }
        Dictionary<int, int> wins = mWindowLayerSiblingIndex[winLayer];
        if (wins.ContainsKey(_winCfg.id))
        {
            List<int> wids = new List<int>(wins.Keys);
            int oldIndex = siblingIndex = wins[_winCfg.id];
            foreach (int d in wids)
            {
                if (oldIndex < wins[d])
                {
                    wins[d] = wins[d] - 1;
                    siblingIndex++;
                }
            }
        }
        else
        {
            siblingIndex = wins.Count;
        }

        if (!mWindowLayerSiblingIndex[winLayer].ContainsKey(_winCfg.id))
        {
            mWindowLayerSiblingIndex[winLayer].Add(_winCfg.id, siblingIndex);
        }
        else
        {
            mWindowLayerSiblingIndex[winLayer][_winCfg.id] = siblingIndex;
        }
        //Debug.LogErrorFormat("Window【{0}】Index【{1}】=>{2}", _winCfg.winName, siblingIndex, mWindowLayerSiblingIndex[winLayer].JsonSerialize());
        return _winCfg;
    }
    #endregion

    #region OnSerializeOpenWindow 序列化打开窗口
    /// <summary>
    /// 打开窗口序列
    /// </summary>
    class OpenWindowSequence
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OpenWindowSequence()
        {
            openWinIds = new List<int>();
            winSequences = new List<int>();
        }
        /// <summary>
        /// 打开的窗id口组
        /// </summary>
        public List<int> openWinIds;
        /// <summary>
        /// 窗口序列
        /// </summary>
        public List<int> winSequences;
    }
    /// <summary>
    /// 打开窗口序列堆【Stack为后进先出,Queue为先进先出】
    /// Key:场景Id
    /// Value:窗口序列
    /// </summary>
    Dictionary<int, Stack<OpenWindowSequence>> mOpenWindowSequenceStack = new Dictionary<int, Stack<OpenWindowSequence>>();

    /// <summary>
    /// 获得场景打开窗口序列
    /// </summary>
    /// <returns>打开窗口序列</returns>
    Stack<OpenWindowSequence> OnGetOpenWindowSequence()
    {
        int sceneId = SceneManager.GetActiveScene().name.UniqueHashCode();
        if (!mOpenWindowSequenceStack.ContainsKey(sceneId))
        {
            mOpenWindowSequenceStack.Add(sceneId, new Stack<OpenWindowSequence>());
        }
        return mOpenWindowSequenceStack[sceneId];
    }

    /// <summary>
    /// 序列化打开模式
    /// </summary>
    /// <param name="_openWinCfgs">打开的窗口配置组</param>
    void OnSerializeOpenWindow(View_UIWindowSetting[] _openWinCfgs)
    {
        Stack<OpenWindowSequence> stackWin = OnGetOpenWindowSequence();
        //是否是同一组窗口打开
        bool isSameWinOpen = stackWin.Count > 0;
        OpenWindowSequence winSeq = null;
        List<int> openWins = new List<int>();
        List<int> openSeqs = new List<int>();
        List<int> closeWins = new List<int>();
        foreach (View_UIWindowSetting w in _openWinCfgs)
        {
            if (!openSeqs.Contains(w.id) && w.openMode != (int)enUIWindowOpenMode.Default)
            {
                openSeqs.Add(w.id);
            }
            if (!openWins.Contains(w.id))
            {
                openWins.Add(w.id);
            }
        }
        if (isSameWinOpen)
        {
            winSeq = stackWin.Peek();
            //判定是否与最后打开的窗口序列一致
            foreach (int id in winSeq.openWinIds)
            {
                isSameWinOpen &= openSeqs.Contains(id);
            }
        }
        //如果不是同一组窗口打开
        if (!isSameWinOpen)
        {
            #region 执行打开模式
            winSeq = new OpenWindowSequence();
            foreach (View_UIWindowSetting cfg in _openWinCfgs)
            {
                if (cfg.openMode != (int)enUIWindowOpenMode.Default)
                {//如果打开模式不是默认模式
                    if (!winSeq.openWinIds.Contains(cfg.id))
                    {
                        winSeq.openWinIds.Add(cfg.id);
                    }
                    #region 收集打开窗口数据                    
                    AbsUIWindowView win = OnGetWindow<AbsUIWindowView>(cfg.id);
                    View_UIWindowSetting cmpCfg = null;
                    bool isSeqWin = false;
                    foreach (int aid in mActiveWindowMaping)
                    {
                        #region 对比当前已实例化的窗口
                        cmpCfg = OnGetWindowSetting(aid)[0];
                        if (!cmpCfg.isIgnoreOpenCloseMode)
                        {//只判定已激活的窗口
                            isSeqWin = false;
                            if (cfg.renderMode == cmpCfg.renderMode)
                            {//如果是相同画布
                                switch (cfg.openMode)
                                {
                                    case (int)enUIWindowOpenMode.WhenDisplayHiddenLessThanSiblingIndex:
                                        isSeqWin = mWindowInstanceMaping[aid].rectTransform.GetSiblingIndex() < win.rectTransform.GetSiblingIndex();
                                        break;
                                    case (int)enUIWindowOpenMode.WhenDisplayHiddenSameLayerAndLessThanSiblingIndex:
                                        isSeqWin = cmpCfg.layer == cfg.layer && mWindowInstanceMaping[aid].rectTransform.GetSiblingIndex() < win.rectTransform.GetSiblingIndex();
                                        break;
                                }
                                if (isSeqWin)
                                {
                                    if (!winSeq.winSequences.Contains(aid))
                                    {
                                        winSeq.winSequences.Add(aid);
                                        //如果是当前要打开的窗口，不需要关闭
                                        if (!openWins.Contains(aid) && !closeWins.Contains(aid))
                                        {
                                            closeWins.Add(aid);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    stackWin.Push(winSeq);
                    #endregion
                }
            }
            #endregion
        }

        foreach (int id in closeWins)
        {
            OnSetWindowActive(mWindowInstanceMaping[id], false);
        }
    }
    #endregion

    #region OnCloseToRestoreSerializeOpenWindow 关闭窗口恢复已打开的序列化窗口
    /// <summary>
    /// 关闭窗口恢复已打开的序列化窗口
    /// </summary>
    /// <param name="_closeWinCfgs">关闭的窗口配置组</param>
    void OnCloseToRestoreSerializeOpenWindow(View_UIWindowSetting[] _closeWinCfgs)
    {
        Stack<OpenWindowSequence> stackWin = OnGetOpenWindowSequence();
        if (stackWin.Count > 0)
        {//如果有打开窗口序列
            OpenWindowSequence dms = stackWin.Peek();
            bool isSameSeq = true;
            //是否与最后打开的窗口序列一致
            foreach (View_UIWindowSetting cfg in _closeWinCfgs)
            {
                isSameSeq &= dms.openWinIds.Contains(cfg.id);
            }

            if (isSameSeq)
            {//如果关闭的窗口是最后的打开窗口序列
                List<View_UIWindowSetting> configs = new List<View_UIWindowSetting>();
                for (int i = 0; i < dms.winSequences.Count; i++)
                {
                    configs.Add(OnPresetAdjustWindowSiblingIndex(OnGetWindowSetting(dms.winSequences[i])[0]));
                }
                OnLoadWindowInMemory<AbsUIWindowView>(configs.ToArray(), null, null, (cfg, result, cfgCall, winCall, pts) =>
                {
                    OnInstanceAndOpenWindow<AbsUIWindowView>(cfg, result, winCall, false, pts);
                    stackWin.Pop();
                });
            }
        }
    }
    #endregion

    #region OnSerializeCloseWindow 序列化关闭窗口
    /// <summary>
    /// 序列化关闭窗口
    /// </summary>
    /// <param name="_winCfgs">窗口配置</param>
    void OnSerializeCloseWindow(View_UIWindowSetting[] _winCfgs)
    {
        foreach (View_UIWindowSetting cfg in _winCfgs)
        {
            if (cfg.closeMode != (int)enUIWindowCloseMode.Default)
            {
                #region 处理关闭窗口数据
                AbsUIWindowView win = OnGetWindow<AbsUIWindowView>(cfg.id);
                View_UIWindowSetting cmpCfg = null;
                bool isCloseWin = false;
                foreach (AbsUIWindowView cmpWin in mWindowInstanceMaping.Values)
                {
                    cmpCfg = cmpWin.config;
                    if (!cmpCfg.isIgnoreOpenCloseMode)
                    {
                        isCloseWin = false;
                        if (cfg.renderMode == cmpCfg.renderMode)
                        {
                            switch (cfg.closeMode)
                            {
                                case (int)enUIWindowCloseMode.WhenCloseHiddenMoreThanSiblingIndex:
                                    isCloseWin = cmpWin.rectTransform.GetSiblingIndex() > win.rectTransform.GetSiblingIndex();
                                    break;
                                case (int)enUIWindowCloseMode.WhenCloseHiddenSameLayerAndMoreThanSiblingIndex:
                                    isCloseWin = cmpCfg.layer == cfg.layer && cmpWin.rectTransform.GetSiblingIndex() > win.rectTransform.GetSiblingIndex();
                                    break;
                            }
                            if (isCloseWin)
                            {
                                OnSetWindowActive(cmpWin, false);
                            }
                        }
                    }
                }
                #endregion
            }
        }
    }
    #endregion

    #region OnRecordWindowSequence 记录窗口序列 OnRestoreWindowSequence 恢复窗口序列
    /// <summary>
    /// 等待恢复的窗口序列
    /// Key:场景Id
    /// Value:窗口组
    /// </summary>
    Dictionary<int, List<int>> mWaitRestoreWindowSequence = new Dictionary<int, List<int>>();
    /// <summary>
    /// 记录窗口序列
    /// </summary>
    void OnRecordWindowSequence()
    {
        int sceneId = SceneManager.GetActiveScene().name.UniqueHashCode();
        if (!mWaitRestoreWindowSequence.ContainsKey(sceneId))
        {
            mWaitRestoreWindowSequence.Add(sceneId, new List<int>());
        }
        foreach (KeyValuePair<int, AbsUIWindowView> key in mWindowInstanceMaping)
        {
            if (key.Value.gameObject.activeSelf &&
                !mWaitRestoreWindowSequence[sceneId].Contains(key.Key) &&
                !key.Value.config.isNotAutoRestoreSequenceWindow)
            {
                mWaitRestoreWindowSequence[sceneId].Add(key.Key);
            }
        }
    }

    /// <summary>
    /// 恢复窗口序列
    /// </summary>
    /// <param name="_onComplete">完成回调</param>
    void OnRestoreWindowSequence(Action<AbsUIWindowView[]> _onComplete)
    {
        int sceneId = SceneManager.GetActiveScene().name.UniqueHashCode();
        if (mWaitRestoreWindowSequence.ContainsKey(sceneId))
        {
            if (mWaitRestoreWindowSequence[sceneId].Count > 0)
            {
                List<View_UIWindowSetting> cfgs = new List<View_UIWindowSetting>();
                foreach (int wid in mWaitRestoreWindowSequence[sceneId])
                {
                    cfgs.Add(OnPresetAdjustWindowSiblingIndex(OnGetWindowSetting(wid)[0]));
                }
                OnLoadWindowInMemory<AbsUIWindowView>(cfgs.ToArray(), null,
                    (wins, pts) =>
                    {
                        Action<AbsUIWindowView[]> call = (Action<AbsUIWindowView[]>)pts[0];
                        call(wins);
                    },
                    (cfg, result, cfgCall, winCall, pts) =>
                    {
                        OnInstanceAndOpenWindow<AbsUIWindowView>(cfg, result, winCall, false, pts);
                    }, _onComplete);
                mWaitRestoreWindowSequence.Clear();
            }
        }
        else
        {
            _onComplete(new AbsUIWindowView[0]);
        }
    }
    #endregion

    #region OnSetWindowActive 设置窗口激活状态
    /// <summary>
    /// 窗口异步映射
    /// </summary>
    Dictionary<int, Coroutine> mWindowCoroutineMaping = new Dictionary<int, Coroutine>();
    /// <summary>
    /// 已激活窗口映射
    /// </summary>
    List<int> mActiveWindowMaping = new List<int>();
    /// <summary>
    /// 设置窗口激活状态
    /// </summary>
    /// <param name="_win">窗口</param>
    /// <param name="_isActive">激活状态</param>
    void OnSetWindowActive(AbsUIWindowView _win, bool _isActive)
    {
        //记录被激活的窗口
        if (_isActive)
        {
            if (!mActiveWindowMaping.Contains(_win.config.id))
            {
                mActiveWindowMaping.Add(_win.config.id);
            }
        }
        else
        {
            mActiveWindowMaping.Remove(_win.config.id);
        }
        //停止在执行的协程
        if (!mWindowCoroutineMaping.ContainsKey(_win.config.id))
        {
            mWindowCoroutineMaping.Add(_win.config.id, null);
        }
        if (mWindowCoroutineMaping[_win.config.id] != null)
        {
            StopCoroutine(mWindowCoroutineMaping[_win.config.id]);
        }
        //设置窗口激活状态
        if (_win.gameObject.activeSelf != _isActive)
        {
            StartCoroutine(DispathActiveEvent(_win, _isActive));
            if (_win.config.isImmediateDisplay)
            {
                _win.SetActiveImmediate(_isActive);
            }
            else
            {
                mWindowCoroutineMaping[_win.config.id] = StartCoroutine(_win.SetActiveYield(_isActive));
            }
        }
    }
    /// <summary>
    /// 发布激活状态事件
    /// </summary>
    /// <param name="_winId">窗口id</param>
    /// <param name="_isActive">激活状态</param>
    /// <returns>异步</returns>
    IEnumerator DispathActiveEvent(AbsUIWindowView _winId, bool _isActive)
    {
        yield return null;
        if (OnChangeWindowActive != null)
        {
            OnChangeWindowActive.Invoke(_winId, _isActive);
        }
    }
    #endregion

    #region OnDispose
    /// <summary>
    /// OnDispose
    /// </summary>
    protected override void OnDispose()
    {
        if (mWindowInstanceMaping.Count > 0)
        {
            List<int> winIds = new List<int>(mWindowInstanceMaping.Keys);
            View_UIWindowSetting config = null;
            foreach (int id in winIds)
            {
                config = OnGetWindowSetting(id)[0];
                if (!config.isDonotDestroyInstance)
                {
                    StartCoroutine(DispathActiveEvent(OnGetWindow<AbsUIWindowView>(id), false));
                    mWindowInstanceMaping[id].Dispose();
                    mWindowInstanceMaping[id] = null;
                    mWindowInstanceMaping.Remove(id);
                }
                else if (!config.isManualCloseWhenGotoScene)
                {
                    OnSetWindowActive(mWindowInstanceMaping[id], false);
                }
            }
        }
        mWindowLayerSiblingIndex.Clear();
        mWindowCoroutineMaping.Clear();
        mActiveWindowMaping.Clear();
        int layer = 0;
        foreach (AbsUIWindowView w in mWindowInstanceMaping.Values)
        {
            layer = (int)w.config.layer;
            if (!mWindowLayerSiblingIndex.ContainsKey(layer))
            {
                mWindowLayerSiblingIndex.Add(layer, new Dictionary<int, int>());
            }
            if (!mWindowLayerSiblingIndex[layer].ContainsKey(w.config.id))
            {
                mWindowLayerSiblingIndex[layer].Add(w.config.id, w.rectTransform.GetSiblingIndex());
            }
            if (!mActiveWindowMaping.Contains(w.config.id) && w.gameObject.activeSelf)
            {
                mActiveWindowMaping.Add(w.config.id);
            }
        }
    }
    #endregion

    #region OnOpenWindow 打开窗口
    /// <summary>
    /// 打开窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_winCallback">窗口回调</param>
    /// <param name="_parameters">参数组</param>
    void OnOpenWindow<W>(View_UIWindowSetting[] _windowIds, UIWindowEntityEventHandler<W> _winCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        foreach (View_UIWindowSetting c in _windowIds)
        {
            OnPresetAdjustWindowSiblingIndex(c);
        }

        OnPreloadWindow<W>(_windowIds, null, _winCallback,
            (cfg, result, cfgCall, winCall, pts) =>
            {
                OnInstanceAndOpenWindow<W>(cfg, result, winCall, true, pts);
            },
            _parameters);
    }
    #endregion

    #region OnInstanceAndOpenWindow 实例化并开启窗口
    /// <summary>
    /// 窗口实例映射
    /// Key:窗口Id
    /// Value:窗口
    /// </summary>
    Dictionary<int, AbsUIWindowView> mWindowInstanceMaping = new Dictionary<int, AbsUIWindowView>();

    /// <summary>
    /// 实例化并开启窗口
    /// </summary>    
    /// <param name="_winCfgs">窗口配置组</param>
    /// <param name="_result">内存结果</param>
    /// <param name="_winCallback">窗口回调</param>
    /// <param name="_isSerializeOpenWindow">是否序列化打开窗口</param>
    /// <param name="_parameters">参数组</param>
    void OnInstanceAndOpenWindow<W>(View_UIWindowSetting[] _winCfgs, Dictionary<int, AssetBundleResult> _result, UIWindowEntityEventHandler<W> _winCallback, bool _isSerializeOpenWindow, params object[] _parameters)
        where W : AbsUIWindowView
    {
        List<W> windows = new List<W>();
        foreach (View_UIWindowSetting cfg in _winCfgs)
        {
            W window = default(W);
            #region 实例化窗口
            if (!mWindowInstanceMaping.ContainsKey(cfg.id))
            {
                GameObject prefab = _result[cfg.id].Instantiate<GameObject>();
                if (prefab != null)
                {
                    prefab.SetActive(false);
                    prefab.name = cfg.name + "[" + cfg.id + "]";
                    window = prefab.AddComponent<W>();
                    window.SetConfig(cfg);
                    OnGetCanvas((RenderMode)cfg.renderMode).AttachWindow(window);
                    mWindowInstanceMaping.Add(cfg.id, window);
                }
            }
            else
            {
                window = (W)mWindowInstanceMaping[cfg.id];
            }
            #endregion

            #region 调整窗口深度
            window.rectTransform.SetSiblingIndex(mWindowLayerSiblingIndex[(int)cfg.layer][cfg.id]);
            #endregion

            windows.Add(window);
        }

        if (_isSerializeOpenWindow)
        {
            //序列化打开窗口
            OnSerializeOpenWindow(_winCfgs);
        }
        foreach (W w in windows)
        {
            OnSetWindowActive(w, true);
        }
        if (_winCallback != null)
        {
            _winCallback.Invoke(windows.ToArray(), _parameters);
        }
    }
    #endregion

    #region OnCloseWindow 关闭窗口
    /// <summary>
    /// 关闭窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_winCallback">窗口回调</param>
    /// <param name="_parameters">参数组</param>
    void OnCloseWindow<W>(View_UIWindowSetting[] _windows, UIWindowEntityEventHandler<W> _winCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        List<int> closeWins = new List<int>();
        List<W> windows = new List<W>();
        foreach (View_UIWindowSetting cfg in _windows)
        {
            W win = OnGetWindow<W>(cfg.id);
            if (win == null)
            {
                Debug.LogErrorFormat("Null window 【{0}】", cfg.name);
            }
            OnSetWindowActive(win, false);
            windows.Add(win);
        }
        //序列化关闭模式
        OnSerializeCloseWindow(_windows);
        //关闭窗口后恢复序列化打开窗口
        OnCloseToRestoreSerializeOpenWindow(_windows);
        if (_winCallback != null)
        {
            _winCallback.Invoke(windows.ToArray(), _parameters);
        }
    }
    #endregion

    #region OnGetWindow 获得窗口
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowIds">窗口Id组</param>
    /// <param name="_winCallback">窗口回调</param>
    /// <param name="_parameters">参数组</param>
    void OnGetWindow<W>(View_UIWindowSetting[] _windows, UIWindowEntityEventHandler<W> _winCallback, params object[] _parameters)
        where W : AbsUIWindowView
    {
        List<W> result = new List<W>();
        if (_windows != null && _windows.Length > 0)
        {
            foreach (View_UIWindowSetting w in _windows)
            {
                result.Add(OnGetWindow<W>(w.id));
            }
        }
        if (_winCallback != null)
        {
            _winCallback.Invoke(result.ToArray(), _parameters);
        }
    }
    /// <summary>
    /// 获得窗口
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windowId">窗口Id</param>
    W OnGetWindow<W>(int _windowId)
    where W : AbsUIWindowView
    {
        return mWindowInstanceMaping.ContainsKey(_windowId) ? (W)mWindowInstanceMaping[_windowId] : default(W);
    }
    #endregion

    #region OnIsExistsWindow 窗口是否存在
    /// <summary>
    /// 窗口组是否存在
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windows">窗口组</param>
    /// <returns>true:存在,false:不存在</returns>
    bool OnIsExistsWindow(params int[] _windows)
    {
        bool isExists = _windows != null && _windows.Length > 0;
        if (isExists)
        {
            foreach (int id in _windows)
            {
                isExists &= mWindowInstanceMaping.ContainsKey(id);
            }
        }
        return isExists;
    }
    #endregion

    #region OnIsOpenedWindow 窗口组是否打开
    /// <summary>
    /// 窗口组是否打开
    /// </summary>
    /// <typeparam name="W">窗口类型</typeparam>
    /// <param name="_windows">窗口组</param>
    /// <returns>true:打开,false:未打开</returns>
    bool OnIsOpenedWindow(params int[] _windows)
    {
        bool isOpened = _windows != null && _windows.Length > 0;
        if (isOpened)
        {
            foreach (int id in _windows)
            {
                isOpened &= mWindowInstanceMaping.ContainsKey(id) && mWindowInstanceMaping[id].isActiveAndEnabled;
            }
        }
        return isOpened;
    }
    #endregion
}
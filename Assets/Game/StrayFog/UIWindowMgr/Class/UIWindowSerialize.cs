using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 窗口占位符句柄
/// </summary>
/// <returns>窗口点位符映射</returns>
public delegate Dictionary<int, UIWindowHolder> WindowHolderMapingEventHandler();

/// <summary>
/// 窗口实例检测
/// </summary>
[AddComponentMenu("StrayFog/Game/UI/UIWindowSerialize")]
public class UIWindowSerialize : AbsMonoBehaviour
{
    /// <summary>
    /// 搜索所有的窗口占位符
    /// </summary>
    public event WindowHolderMapingEventHandler OnSearchAllWindowHolders;

    /// <summary>
    /// 窗口序列
    /// </summary>
    class WindowSequence
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_openWindows">打开的窗口</param>
        /// <param name="_sequenceCloseWindows">序列化关闭的窗口</param>
        public WindowSequence(List<int> _openWindows, List<int> _sequenceCloseWindows)
        {
            openWindows = _openWindows;
            sequenceCloseWindows = _sequenceCloseWindows;
        }

        /// <summary>
        /// 是否是相同的开启窗口
        /// </summary>
        /// <param name="_openWindows">开启窗口</param>
        /// <returns>true:是,false:否</returns>
        public bool IsSameOpenWindow(List<int> _openWindows)
        {
            bool isSame = _openWindows.Count == openWindows.Count;
            if (isSame)
            {
                for (int i = 0; i < _openWindows.Count; i++)
                {
                    isSame &= _openWindows[i] == openWindows[i];
                }
            }
            return isSame;
        }

        /// <summary>
        /// 打开的窗口
        /// </summary>
        public List<int> openWindows { get; private set; }
        /// <summary>
        /// 序列化关闭窗口
        /// </summary>
        public List<int> sequenceCloseWindows { get; private set; }
    }

    /// <summary>
    /// 自动存储序列化映射
    /// </summary>
    Dictionary<int, Stack<WindowSequence>> mAutoRestoreSequenceStack = new Dictionary<int, Stack<WindowSequence>>();
    
    /// <summary>
    /// 开启窗口序列
    /// </summary>
    /// <param name="_winCfgs">窗口配置组</param>
    public void OpenWindowSerialize(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        Dictionary<int, int> sameLayerLessThenSiblingIndex = new Dictionary<int, int>();
        List<int> lessThenSiblingIndex = new List<int>();
        Dictionary<int, UIWindowHolder> winHolders = OnSearchAllWindowHolders();
        List<int> openWinIds = new List<int>();
        List<int> sequenceCloseWinIds = new List<int>();
        if (_winCfgs != null && _winCfgs.Length >0)
        {
            #region 统计需要隐藏的各层级的最大SiblingIndex
            foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
                if (!openWinIds.Contains(cfg.id))
                {
                    openWinIds.Add(cfg.id);
                }
                switch (cfg.winOpenMode)
                {
                    case enUIWindowOpenMode.WhenDisplayHiddenSameLayerAndLessThanSiblingIndex:
                        if (!sameLayerLessThenSiblingIndex.ContainsKey(cfg.layer))
                        {
                            sameLayerLessThenSiblingIndex.Add(cfg.layer, winHolders[cfg.id].windowSiblingIndex);
                        }
                        else
                        {
                            sameLayerLessThenSiblingIndex[cfg.layer] = Mathf.Max(sameLayerLessThenSiblingIndex[cfg.layer], winHolders[cfg.id].windowSiblingIndex);
                        }
                        break;
                    case enUIWindowOpenMode.WhenDisplayHiddenLessThanSiblingIndex:
                        if (!lessThenSiblingIndex.Contains(winHolders[cfg.id].windowSiblingIndex))
                        {
                            lessThenSiblingIndex.Add(winHolders[cfg.id].windowSiblingIndex);
                        }
                        else
                        {
                            lessThenSiblingIndex[0] = Mathf.Max(lessThenSiblingIndex[0], winHolders[cfg.id].windowSiblingIndex);
                        }
                        break;                    
                }
            }
            #endregion
        }
        List<int> hiddenWinIds = new List<int>();
        if (winHolders != null && winHolders.Count > 0)
        {
            #region 收集要隐藏的窗口ID
            foreach (KeyValuePair<int, UIWindowHolder> holder in winHolders)
            {
                if (
                    sameLayerLessThenSiblingIndex.ContainsKey(holder.Value.winCfg.layer)
                    && holder.Value.windowSiblingIndex < sameLayerLessThenSiblingIndex[holder.Value.winCfg.layer]
                    )
                {
                    if (!hiddenWinIds.Contains(holder.Key))
                    {
                        hiddenWinIds.Add(holder.Key);
                    }
                    if (!sequenceCloseWinIds.Contains(holder.Key) && holder.Value.winCfg.isAutoRestoreSequenceWindow)
                    {
                        sequenceCloseWinIds.Add(holder.Key);
                    }
                }
                if (
                    lessThenSiblingIndex.Count > 0
                    && holder.Value.windowSiblingIndex < lessThenSiblingIndex[0]
                    )
                {
                    if (!hiddenWinIds.Contains(holder.Key))
                    {
                        hiddenWinIds.Add(holder.Key);
                    }
                    if (!sequenceCloseWinIds.Contains(holder.Key) && holder.Value.winCfg.isAutoRestoreSequenceWindow)
                    {
                        sequenceCloseWinIds.Add(holder.Key);
                    }
                }
            }
            #endregion
        }

        foreach(int wid in hiddenWinIds)
        {
            winHolders[wid].SetTargetActive(false);
        }

        Stack<WindowSequence> winSeq = OnGetOpenWindowSequence();
        if (winSeq.Count > 0)
        {
            WindowSequence ws = winSeq.Peek();
            if (!ws.IsSameOpenWindow(openWinIds))
            {
                winSeq.Push(new WindowSequence(openWinIds, sequenceCloseWinIds));
            }
        }
        else if(openWinIds.Count > 0)
        {
            winSeq.Push(new WindowSequence(openWinIds, sequenceCloseWinIds));
        }
#if DEBUGLOG
        Debug.LogFormat("sameLayerLessThenSiblingIndex【{0}】,lessThenSiblingIndex【{1}】,hiddenWinIds【{2}】",
            sameLayerLessThenSiblingIndex.JsonSerialize(), lessThenSiblingIndex.JsonSerialize(), hiddenWinIds.JsonSerialize());
        Debug.LogFormat("open windows=>【{0}】,sequence close windows=>【{1}】", openWinIds.JsonSerialize(), sequenceCloseWinIds.JsonSerialize());
#endif
    }

    /// <summary>
    /// 获得场景打开窗口序列
    /// </summary>
    /// <returns>打开窗口序列</returns>
    Stack<WindowSequence> OnGetOpenWindowSequence()
    {
        int sceneId = SceneManager.GetActiveScene().name.UniqueHashCode();
        if (!mAutoRestoreSequenceStack.ContainsKey(sceneId))
        {
            mAutoRestoreSequenceStack.Add(sceneId, new Stack<WindowSequence>());
        }
        return mAutoRestoreSequenceStack[sceneId];
    }

    /// <summary>
    /// 获得自动存储序列
    /// </summary>
    /// <param name="_closeWinIds">关闭的窗口组</param>
    /// <returns>存储序列</returns>
    public List<int> GetAutoRestoreSequence(List<int> _closeWinIds)
    {
        List<int> winIds = new List<int>();
        Stack<WindowSequence> stack = OnGetOpenWindowSequence();
#if DEBUGLOG
        Debug.LogFormat("【Before】GetAutoRestoreSequence=>Close【{0}】,Stack=>【{1}】", _closeWinIds.JsonSerialize(), stack.JsonSerialize());
#endif
        if (stack.Count > 0)
        {
            WindowSequence ws = stack.Peek();
            if (ws.IsSameOpenWindow(_closeWinIds))
            {
                winIds = ws.sequenceCloseWindows;
                stack.Pop();
            }            
        }
#if DEBUGLOG
        Debug.LogFormat("【After】GetAutoRestoreSequence=>Close【{0}】,Stack=>【{1}】", _closeWinIds.JsonSerialize(), stack.JsonSerialize());
#endif
        return winIds;
    }

    /// <summary>
    /// 保存场景切换窗口序列
    /// </summary>
    public void SaveToggleSceneWindowSequence()
    {
        Stack<WindowSequence> stack = OnGetOpenWindowSequence();
        Dictionary<int, UIWindowHolder> winHolders = OnSearchAllWindowHolders();
        List<int> closeWinIds = new List<int>();
        foreach (UIWindowHolder holder in winHolders.Values)
        {
            if (
                holder.winCfg.isAutoRestoreSequenceWindow 
                && !closeWinIds.Contains(holder.winCfg.id)
                && holder.WindowIsActiveAndEnabled()
                )
            {
                closeWinIds.Add(holder.winCfg.id);
            }
        }
        if (closeWinIds.Count > 0)
        {
            stack.Push(new WindowSequence(new List<int>(), closeWinIds));
        }        
    }

    /// <summary>
    /// 恢复场景切换窗口序列
    /// </summary>
    /// <returns>窗口组</returns>
    public List<int> RestoreToggleSceneWindowSequence()
    {
        List<int> winIds = new List<int>();
        Stack<WindowSequence> stack = OnGetOpenWindowSequence();
        if (stack.Count > 0)
        {
            Dictionary<int, UIWindowHolder> winHolders = OnSearchAllWindowHolders();
            WindowSequence ws = stack.Pop();
            winIds = ws.sequenceCloseWindows;
        }
        return winIds;
    }
}

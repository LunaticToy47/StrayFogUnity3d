using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 窗口占位符句柄
/// </summary>
/// <returns>窗口点位符映射</returns>
public delegate Dictionary<int, UIWindowHolder> WindowHolderMapingEventHandler();

/// <summary>
/// 窗口实例检测
/// </summary>
[AddComponentMenu("Game/UI/UIWindowSerialize")]
public class UIWindowSerialize : AbsMonoBehaviour
{
    /// <summary>
    /// 搜索所有的窗口占位符
    /// </summary>
    public event WindowHolderMapingEventHandler OnSearchAllWindowHolders;

    /// <summary>
    /// 被隐藏的窗口队列
    /// </summary>
    Stack<List<int>> mQueueHiddenWindow = new Stack<List<int>>();
    /// <summary>
    /// 开启窗口序列
    /// </summary>
    /// <param name="_winCfgs">窗口配置组</param>
    public void OpenWindowSerialize(XLS_Config_Table_UIWindowSetting[] _winCfgs)
    {
        Dictionary<int, int> sameLayerLessThenSiblingIndex = new Dictionary<int, int>();
        List<int> lessThenSiblingIndex = new List<int>();
        Dictionary<int, UIWindowHolder> winHolders = OnSearchAllWindowHolders();
        if (_winCfgs != null && _winCfgs.Length >0)
        {
            #region 统计需要隐藏的各层级的最大SiblingIndex
            foreach (XLS_Config_Table_UIWindowSetting cfg in _winCfgs)
            {
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
                    && !hiddenWinIds.Contains(holder.Key)
                    )
                {
                    hiddenWinIds.Add(holder.Key);
                }
                if (
                    lessThenSiblingIndex.Count > 0
                    && holder.Value.windowSiblingIndex < lessThenSiblingIndex[0]
                    && !hiddenWinIds.Contains(holder.Key)
                    )
                {
                    hiddenWinIds.Add(holder.Key);
                }
            }
            #endregion
        }

#if UNITY_EDITOR
        Debug.LogFormat("sameLayerLessThenSiblingIndex【{0}】,lessThenSiblingIndex【{1}】,hiddenWinIds【{2}】",
            sameLayerLessThenSiblingIndex.JsonSerialize(), lessThenSiblingIndex.JsonSerialize(), hiddenWinIds.JsonSerialize());
#endif
        if (hiddenWinIds.Count > 0)
        {
            mQueueHiddenWindow.Push(hiddenWinIds);
        }        
    }

    /// <summary>
    /// 执行打开窗口后操作
    /// </summary>
    public void ExecuteAfterOpenWindow()
    {
        Dictionary<int, UIWindowHolder> winHolders = OnSearchAllWindowHolders();
        List<int> winIds = new List<int>();
        if (mQueueHiddenWindow.Count > 0)
        {
            winIds = mQueueHiddenWindow.Peek();
        }
#if UNITY_EDITOR
        Debug.LogFormat("ExecuteAfterOpenWindow【{0}】", winIds.JsonSerialize());
#endif
        foreach (int id in winIds)
        {
            winHolders[id].ToggleActive(false);
        }
    }

    /// <summary>
    /// 导出序列
    /// </summary>
    /// <returns>窗口配置组</returns>
    public XLS_Config_Table_UIWindowSetting[] DeSerialize()
    {
        return null;
    }
}

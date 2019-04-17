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
#if UNITY_EDITOR
        List<int> hiddenWinIds = new List<int>();
#endif
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
                    holder.Value.SetTargetActive(false);
#if UNITY_EDITOR
                    if (!hiddenWinIds.Contains(holder.Key))
                    {
                        hiddenWinIds.Add(holder.Key);
                    }
#endif
                }
                if (
                    lessThenSiblingIndex.Count > 0
                    && holder.Value.windowSiblingIndex < lessThenSiblingIndex[0]
                    )
                {
                    holder.Value.SetTargetActive(false);
#if UNITY_EDITOR
                    if (!hiddenWinIds.Contains(holder.Key))
                    {
                        hiddenWinIds.Add(holder.Key);
                    }
#endif
                }
            }
            #endregion
        }
        
#if UNITY_EDITOR
        Debug.LogFormat("sameLayerLessThenSiblingIndex【{0}】,lessThenSiblingIndex【{1}】,hiddenWinIds【{2}】",
            sameLayerLessThenSiblingIndex.JsonSerialize(), lessThenSiblingIndex.JsonSerialize(), hiddenWinIds.JsonSerialize());
#endif
    }
}

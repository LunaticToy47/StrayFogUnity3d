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
    /// 加入序列
    /// </summary>
    /// <param name="_winCfgs">窗口配置组</param>
    public void EnSerialize(XLS_Config_Table_UIWindowSetting[] _winCfgs)
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

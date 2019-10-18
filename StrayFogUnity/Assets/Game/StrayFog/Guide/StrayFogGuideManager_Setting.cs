using System.Collections.Generic;
/// <summary>
/// 引导管理器【设置数据】
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 引导窗口Id
    /// </summary>
    int mGuideWindowId = 0;
    /// <summary>
    /// 等待触发引导
    /// </summary>
    List<int> mWaitTriggerGuides = new List<int>();    
    /// <summary>
    /// 引导配置映射
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideConfig> mGuideConfigMaping = new Dictionary<int, XLS_Config_Table_UserGuideConfig>();

    #region OnInitGuideWindowData 初始化引导窗口数据
    /// <summary>
    /// 初始化引导窗口数据
    /// </summary>
    void OnInitGuideWindowData()
    {        
        List<XLS_Config_Table_UIWindowSetting> guides = StrayFogGamePools.uiWindowManager.GetWindowSettings((w) => { return w.isGuideWindow; });
        if (guides != null && guides.Count > 0)
        {
            List<int> ids = new List<int>();
            foreach (XLS_Config_Table_UIWindowSetting w in guides)
            {
                if (!ids.Contains(w.id))
                {
                    ids.Add(w.id);
                }
            }
            mGuideWindowId = ids[0];
        }        
    }
    #endregion

    #region OnInitGuideConfigData 初始化引导数据
    /// <summary>
    /// 初始化引导数据
    /// </summary>
    void OnInitGuideConfigData()
    {        
        List<XLS_Config_Table_UserGuideConfig> triggers = StrayFogSQLiteEntityHelper.Select<XLS_Config_Table_UserGuideConfig>();
        if (triggers != null && triggers.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideConfig t in triggers)
            {
                if (!mGuideConfigMaping.ContainsKey(t.id))
                {
                    mGuideConfigMaping.Add(t.id, t);
                }
                if (!mWaitTriggerGuides.Contains(t.id))
                {
                    mWaitTriggerGuides.Add(t.id);
                }
            }
        }        
    }
    #endregion

    #region FilterGuide 过滤引导
    /// <summary>
    /// 过滤引导
    /// </summary>
    /// <param name="_excludeFilterIds">要排除的过滤id组</param>
    public void FilterGuide(params int[] _excludeFilterIds)
    {
        if (_excludeFilterIds != null && _excludeFilterIds.Length > 0)
        {
            foreach (int id in _excludeFilterIds)
            {
                mWaitTriggerGuides.Remove(id);
            }
        }
    }
    #endregion
}

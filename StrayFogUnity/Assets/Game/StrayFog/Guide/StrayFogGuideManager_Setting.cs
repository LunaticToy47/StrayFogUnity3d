using System;
using System.Collections.Generic;
/// <summary>
/// 引导管理器【设置数据】
/// </summary>
public partial class StrayFogGuideManager
{
    /// <summary>
    /// 引导窗口Id
    /// </summary>
    public int guideWindowId { get; private set; }

    /// <summary>
    ///引导配置映射
    ///Key:guideId
    ///Value:XLS_Config_Table_UserGuideConfig
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideConfig> mGuideConfigMaping = new Dictionary<int, XLS_Config_Table_UserGuideConfig>();
    /// <summary>
    /// 引导参考对象映射
    ///Key:guideId
    ///Value:XLS_Config_Table_UserGuideReferObject
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideReferObject> mGuideReferObjectMaping = new Dictionary<int, XLS_Config_Table_UserGuideReferObject>();
    /// <summary>
    /// 引导样式映射
    ///Key:guideId
    ///Value:XLS_Config_Table_UserGuideStyle
    /// </summary>
    Dictionary<int, XLS_Config_Table_UserGuideStyle> mGuideStyleMaping = new Dictionary<int, XLS_Config_Table_UserGuideStyle>();
    /// <summary>
    /// 等待引导命令映射
    ///Key:guideId
    ///Value:AbsGuideCommand
    /// </summary>
    Dictionary<int, AbsGuideCommand> mWaitGuideCommandMaping = new Dictionary<int, AbsGuideCommand>();

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
            guideWindowId = ids[0];
        }        
    }
    #endregion

    #region OnInitGuideConfigData 初始化引导数据
    /// <summary>
    /// 初始化引导数据
    /// </summary>
    void OnInitGuideConfigData()
    {        
        List<XLS_Config_Table_UserGuideConfig> configs = StrayFogConfigHelper.Select<XLS_Config_Table_UserGuideConfig>();
        if (configs != null && configs.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideConfig t in configs)
            {
                if (!mGuideConfigMaping.ContainsKey(t.id))
                {
                    mGuideConfigMaping.Add(t.id, t);
                }
            }
        }        
    }
    #endregion

    #region OnInitGuideReferObjectData 初始化引导参考对象数据
    /// <summary>
    /// 初始化引导参考对象数据
    /// </summary>
    void OnInitGuideReferObjectData()
    {
        List<XLS_Config_Table_UserGuideReferObject> referObjects = StrayFogConfigHelper.Select<XLS_Config_Table_UserGuideReferObject>();
        if (referObjects != null && referObjects.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideReferObject t in referObjects)
            {
                if (!mGuideReferObjectMaping.ContainsKey(t.id))
                {
                    mGuideReferObjectMaping.Add(t.id, t);
                }
            }
        }
    }
    #endregion

    #region OnInitGuideStyleData 初始化引导样式数据
    /// <summary>
    /// 初始化引导样式数据
    /// </summary>
    void OnInitGuideStyleData()
    {
        List<XLS_Config_Table_UserGuideStyle> styles = StrayFogConfigHelper.Select<XLS_Config_Table_UserGuideStyle>();
        if (styles != null && styles.Count > 0)
        {
            foreach (XLS_Config_Table_UserGuideStyle s in styles)
            {
                if (!mGuideStyleMaping.ContainsKey(s.id))
                {
                    mGuideStyleMaping.Add(s.id, s);
                }
            }
        }
    }
    #endregion    

    #region OnInitGuideResolveCommand 初始化引导命令
    /// <summary>
    /// 初始化引导命令
    /// </summary>
    void OnInitGuideResolveCommand()
    {
        foreach (XLS_Config_Table_UserGuideConfig cfg in mGuideConfigMaping.Values)
        {
            AbsGuideCommand cmd = OnCreateGuideCommand(cfg);
            if (!mWaitGuideCommandMaping.ContainsKey(cmd.guideConfig.id))
            {
                mWaitGuideCommandMaping.Add(cmd.guideConfig.id, cmd);
            }
        }
    }
    #endregion

    #region FilterGuide 过滤引导
    /// <summary>
    /// 过滤引导
    /// </summary>
    /// <param name="_excludeFilterGuideIds">要排除过滤的引导GuideId组</param>
    public void FilterGuide(params int[] _excludeFilterGuideIds)
    {
        if (_excludeFilterGuideIds != null && _excludeFilterGuideIds.Length > 0)
        {
            foreach (int id in _excludeFilterGuideIds)
            {
                mWaitGuideCommandMaping.Remove(id);
            }
        }
    }
    #endregion
}

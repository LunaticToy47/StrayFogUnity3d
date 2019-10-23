using System.Collections.Generic;
/// <summary>
/// 引导解析匹配抽象
/// </summary>
public class AbsGuideResolveMatch : IGuideMatchCondition, IGuideResolveConfig
{
    /// <summary>
    /// 引导解析匹配命令
    /// </summary>
    List<AbsGuideResolveMatch> mGuideResolveMatchCmds = new List<AbsGuideResolveMatch>();

    #region isMatchCondition 是否满足条件
    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足条件,false:不满足条件</returns>
    public bool isMatchCondition()
    {
        bool result = mGuideResolveMatchCmds == null || mGuideResolveMatchCmds.Count > 0;
        if (mGuideResolveMatchCmds != null)
        {
            foreach (AbsGuideResolveMatch cmd in mGuideResolveMatchCmds)
            {
                result &= cmd.isMatchCondition();
            }
        }
        return result & OnIsMatchCondition();
    }

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <returns>true:满足条件,false:不满足条件</returns>
    protected virtual bool OnIsMatchCondition() { return true; }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config)
    {
        List<AbsGuideResolveMatch> result = OnResolveConfig(_config);
        if (result != null && result.Count > 0)
        {
            mGuideResolveMatchCmds.AddRange(result);
        }
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令组</returns>
    protected virtual List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideConfig _config) { return new List<AbsGuideResolveMatch>(); }
    #endregion

    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        List<AbsGuideResolveMatch> result = OnResolveConfig(_config);
        if (result != null && result.Count > 0)
        {
            mGuideResolveMatchCmds.AddRange(result);
        }
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令组</returns>
    protected virtual List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config) { return new List<AbsGuideResolveMatch>(); }
    #endregion

    #region Clear 清空已解析的数据
    /// <summary>
    /// 清空已解析的数据
    /// </summary>
    public void Clear()
    {
        if (mGuideResolveMatchCmds != null)
        {
            foreach (AbsGuideResolveMatch cmd in mGuideResolveMatchCmds)
            {
                cmd.Clear();
            }
        }
        OnClear();
    }
    /// <summary>
    /// 清空已解析的数据
    /// </summary>
    protected virtual void OnClear() { }
    #endregion
}

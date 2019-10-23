﻿/// <summary>
/// 引导子命令_参考对象抽象
/// </summary>
public class AbsGuideSubCommand_Condition : AbsGuideCondition, IGuideSubCommand_Condition
{
    #region ResolveConfig 解析配置
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    public void ResolveConfig(XLS_Config_Table_UserGuideConfig _config)
    {
        OnResolveConfig(_config);
    }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    protected virtual void OnResolveConfig(XLS_Config_Table_UserGuideConfig _config) { }
    #endregion
}
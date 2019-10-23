using System.Collections.Generic;
/// <summary>
/// 强引导命令
/// </summary>
public class UserGuideConfig_ReferObject_Command : AbsGuideResolveMatch
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令组</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        List<AbsGuideResolveMatch> result = new List<AbsGuideResolveMatch>();
        AbsGuideSubCommand_ReferObject tr2d = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer2DType]();
        tr2d.ResolveConfig(_config);
        result.Add(tr2d);

        AbsGuideSubCommand_ReferObject tr3d = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer3DType]();
        tr3d.ResolveConfig(_config);
        result.Add(tr3d);

        return result;
    }
}

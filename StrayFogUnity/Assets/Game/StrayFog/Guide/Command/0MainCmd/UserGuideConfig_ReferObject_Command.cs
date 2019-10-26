using System.Collections.Generic;
/// <summary>
/// 引导参考对象结构
/// </summary>
public class UserGuideConfig_ReferObject_Command : AbsGuideSubCommand_ReferObject
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_referObjectIndex">参考对象索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config,int _referObjectIndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        base.OnResolveConfig(_config, _referObjectIndex, _resolveStatus, _status);
        List<AbsGuideResolveMatch> result = new List<AbsGuideResolveMatch>();
        result.Add(StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer2DType]());
        result.Add(StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_config.refer3DType]());
        return result;
    }
}

using System.Collections.Generic;
/// <summary>
/// 引导触发条件_参考对象
/// </summary>
public class UserGuideConfig_TriggerCondition_ReferObject : AbsGuideSubCommand_Condition
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_guideConfig">引导配置</param>
    /// <param name="_referObjectConfig">参考对象配置</param>
    /// <param name="_styleConfig">样式配置</param>
    /// <param name="_conditionIndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>条件命令组</returns>
    protected override List<AbsGuideSubCommand_Condition> OnResolveConfig(XLS_Config_Table_UserGuideConfig _guideConfig,
        XLS_Config_Table_UserGuideReferObject _referObjectConfig,
        XLS_Config_Table_UserGuideStyle _styleConfig,
        int _conditionIndex, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        List<AbsGuideSubCommand_Condition> result = new List<AbsGuideSubCommand_Condition>();
        result.Add(StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_referObjectConfig.refer2DType]());
        result.Add(StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DTypeMaping[_referObjectConfig.refer3DType]());
        return result;
    }
}

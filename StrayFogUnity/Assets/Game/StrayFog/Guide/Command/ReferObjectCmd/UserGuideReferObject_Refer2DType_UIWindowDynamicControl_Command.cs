using System.Collections.Generic;
/// <summary>
/// 参考对象UI窗口动态生成控件
/// </summary>
public class UserGuideReferObject_Refer2DType_UIWindowDynamicControl_Command : AbsGuideSubCommand_ReferObject
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <returns>命令组</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config)
    {
        //收集动态组件搜索条件命令
        List<AbsGuideResolveMatch> result = new List<AbsGuideResolveMatch>();
        AbsGuideSubCommand_Condition condition = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DSearchDynamicConditionTypeMaping[_config.refer2DSearchDynamicConditionType]();
        condition.ResolveConfig(_config);
        result.Add(condition);
        return result;
    }
}

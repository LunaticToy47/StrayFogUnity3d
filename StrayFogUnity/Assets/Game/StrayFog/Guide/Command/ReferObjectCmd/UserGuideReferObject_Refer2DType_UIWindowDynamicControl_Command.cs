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
    /// <param name="_index">数据索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    /// <returns>命令集</returns>
    protected override List<AbsGuideResolveMatch> OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _resolveStatus, enGuideStatus _status)
    {
        //收集动态组件搜索条件命令
        return new List<AbsGuideResolveMatch>() { StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DSearchDynamicConditionTypeMaping[_config.refer2DSearchDynamicConditionType]() };
    }
}

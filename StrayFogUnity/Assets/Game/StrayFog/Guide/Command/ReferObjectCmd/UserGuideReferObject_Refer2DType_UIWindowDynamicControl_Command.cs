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
    /// <param name="_status">引导状态</param>
    protected override void OnResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _status)
    {
        //收集动态组件搜索条件命令
        AbsGuideSubCommand_Condition condition = StrayFogGuideManager.Cmd_UserGuideReferObject_Refer2DSearchDynamicConditionTypeMaping[_config.refer2DSearchDynamicConditionType]();
        condition.ResolveConfig(_config, _index, _status);
    }
}

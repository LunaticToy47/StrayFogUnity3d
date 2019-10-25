using System;
/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand
{
    /// <summary>
    /// 当前引导状态
    /// </summary>
    enGuideStatus status { get; }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject);
}

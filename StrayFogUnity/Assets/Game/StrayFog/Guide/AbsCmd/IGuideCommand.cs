using System;
/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand : IGuideMatchCondition,IRecycle
{
    /// <summary>
    /// 引导Id
    /// </summary>
    int guideId { get; }
    /// <summary>
    /// 引导类型
    /// </summary>
    int guideType { get; }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject);

    /// <summary>
    /// 获得当前引导状态
    /// </summary>
    enGuideStatus status { get; }

    /// <summary>
    /// 执行处理
    /// </summary>
    void Excute();
}

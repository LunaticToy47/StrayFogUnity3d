using System;
/// <summary>
/// 引导命令接口
/// </summary>
public interface IGuideCommand
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_funcReferObject">获得参考对象回调</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config,
        Func<int, XLS_Config_Table_UserGuideReferObject> _funcReferObject);

    /// <summary>
    /// 是否满足条件
    /// </summary>
    /// <param name="_status">当前引导状态</param>
    /// <returns>true:满足,false:不满足</returns>
    bool isMatchCmd(params object[] _parameters);

    /// <summary>
    /// 执行处理
    /// </summary>
    /// <param name="_parameters">参数</param>
    void ExcuteCmd(params object[] _parameters);
}

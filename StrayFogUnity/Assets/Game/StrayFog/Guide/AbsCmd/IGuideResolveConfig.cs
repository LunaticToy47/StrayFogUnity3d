/// <summary>
/// 引导解析配置接口
/// </summary>
public interface IGuideResolveConfig
{
    /// <summary>
    /// 引导配置
    /// </summary>
    XLS_Config_Table_UserGuideConfig guideConfig { get; }

    /// <summary>
    /// 参考对象配置
    /// </summary>
    XLS_Config_Table_UserGuideReferObject referObjectConfig { get; }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _index, enGuideStatus _status);

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_index">数据索引</param>
    /// <param name="_status">引导状态</param>
    void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _index, enGuideStatus _status);
}

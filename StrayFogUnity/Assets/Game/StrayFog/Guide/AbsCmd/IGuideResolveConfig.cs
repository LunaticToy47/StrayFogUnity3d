/// <summary>
/// 引导解析配置接口
/// </summary>
public interface IGuideResolveConfig
{
    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config);

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config);

    /// <summary>
    /// 清空已解析的数据
    /// </summary>
    void Clear();
}

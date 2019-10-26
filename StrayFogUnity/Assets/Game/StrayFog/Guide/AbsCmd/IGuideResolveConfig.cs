/// <summary>
/// 引导解析配置接口
/// </summary>
public interface IGuideResolveConfig
{
    /// <summary>
    /// 条件索引
    /// </summary>
    int conditionTndex { get;}
    /// <summary>
    /// 参考对象索引
    /// </summary>
    int referObjectIndex { get; }

    /// <summary>
    /// 参考对象类型
    /// </summary>
    enUserGuideReferObject_ReferType referType { get; }

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
    /// <param name="_conditionTndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _config, int _conditionTndex, enGuideStatus _resolveStatus, enGuideStatus _status);

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_config">配置</param>
    /// <param name="_referObjectIndex">参考对象索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    void ResolveConfig(XLS_Config_Table_UserGuideReferObject _config, int _referObjectIndex, enGuideStatus _resolveStatus, enGuideStatus _status);

    /// <summary>
    /// 解析参考对象
    /// </summary>
    enUserGuideReferObject_ReferType ResolveReferObject();
}

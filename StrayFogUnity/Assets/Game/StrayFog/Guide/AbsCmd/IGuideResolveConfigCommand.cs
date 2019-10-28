/// <summary>
/// 引导解析配置命令接口
/// </summary>
public interface IGuideResolveConfigCommand
{
    /// <summary>
    /// 条件索引
    /// </summary>
    int conditionIndex { get; }
    /// <summary>
    /// 参考对象索引
    /// </summary>
    int referObjectIndex { get; }
    /// <summary>
    /// 样式索引
    /// </summary>
    int styleIndex { get; }

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
    /// 样式配置
    /// </summary>
    XLS_Config_Table_UserGuideStyle styleConfig { get; }

    /// <summary>
    /// 解析配置
    /// </summary>
    /// <param name="_guideConfig">引导配置</param>
    /// <param name="_referObjectConfig">参考对象配置</param>
    /// <param name="_styleConfig">样式配置</param>
    /// <param name="_conditionIndex">条件索引</param>
    /// <param name="_resolveStatus">解析状态</param>
    /// <param name="_status">引导状态</param>
    void ResolveConfig(XLS_Config_Table_UserGuideConfig _guideConfig,
        XLS_Config_Table_UserGuideReferObject _referObjectConfig,
        XLS_Config_Table_UserGuideStyle _styleConfig,
        int _conditionIndex, enGuideStatus _resolveStatus, enGuideStatus _status);

    /// <summary>
    /// 解析参考对象类别
    /// </summary>
    enUserGuideReferObject_ReferType ResolveReferObjectType();
}

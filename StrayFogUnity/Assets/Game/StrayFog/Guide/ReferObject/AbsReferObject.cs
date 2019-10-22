/// <summary>
/// 参考对象抽象
/// </summary>
public abstract class AbsReferObject
{
    /// <summary>
    /// 配置数据
    /// </summary>
    public XLS_Config_Table_UserGuideReferObject config { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_config">配置数据</param>
    public AbsReferObject(XLS_Config_Table_UserGuideReferObject _config)
    {
        config = _config;
    }
}

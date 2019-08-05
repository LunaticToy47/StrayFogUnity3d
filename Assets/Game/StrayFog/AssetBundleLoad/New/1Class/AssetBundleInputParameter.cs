/// <summary>
/// 资源输入参数
/// </summary>
public class AssetBundleInputParameter : IAssetBundleInputParameter
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_config">磁盘配置</param>
    /// <param name="_extraParameter">额外参数</param>
    public AssetBundleInputParameter(XLS_Config_View_AssetDiskMaping _config, object[] _extraParameter)
    {
        uniqueId = _config.inAssetPath.UniqueHashCode();
        config = _config;
        extraParameter = _extraParameter;
    }
    /// <summary>
    /// 唯一Id
    /// </summary>
    public int uniqueId { get; private set; }
    /// <summary>
    /// 磁盘配置
    /// </summary>
    public XLS_Config_View_AssetDiskMaping config { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParameter { get; private set; }
}

using System.IO;
/// <summary>
/// 资源输入
/// </summary>
public class AssetBundleInput : IAssetBundleInput
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_config">磁盘映射配置</param>
    /// <param name="_extraParemeter">额外参数</param>
    public AssetBundleInput(XLS_Config_View_AssetDiskMaping _config, object[] _extraParemeter)
    {
        uniqueId = _config.inAssetPath.UniqueHashCode();
        config = _config;
        extraParameter = _extraParemeter;
        assetName = Path.GetFileNameWithoutExtension(_config.fileName);
    }
    /// <summary>
    /// 唯一ID
    /// </summary>
    public int uniqueId { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string assetName { get; private set; }
    /// <summary>
    /// 磁盘映射配置
    /// </summary>
    public XLS_Config_View_AssetDiskMaping config { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParameter { get; private set; }
}

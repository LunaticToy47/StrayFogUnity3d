/// <summary>
/// 资源输入
/// </summary>
public interface IAssetBundleInput
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    int uniqueId { get; }
    /// <summary>
    /// 资源名称
    /// </summary>
    string assetName { get;}
    /// <summary>
    /// 磁盘映射配置
    /// </summary>
    XLS_Config_View_AssetDiskMaping config { get; }
    /// <summary>
    /// 额外参数
    /// </summary>
    object[] extraParameter { get; }
}

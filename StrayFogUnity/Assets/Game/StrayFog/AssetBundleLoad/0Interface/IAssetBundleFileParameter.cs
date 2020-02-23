/// <summary>
/// 资源文件参数
/// </summary>
public interface IAssetBundleFileParameter
{
    /// <summary>
    /// 资源ID
    /// </summary>
    int assetBundleId { get; }
    /// <summary>
    /// 资源名称
    /// </summary>
    string assetBundleName { get; }
    /// <summary>
    /// 资源路径
    /// </summary>
    string assetBundlePath { get; }
    /// <summary>
    /// 是否是内部资源
    /// </summary>
    bool isUseAssetBundle { get; }
}

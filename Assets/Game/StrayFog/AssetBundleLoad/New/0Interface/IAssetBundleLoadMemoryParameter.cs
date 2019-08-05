/// <summary>
/// 资源内存加载参数
/// </summary>
public interface IAssetBundleLoadMemoryParameter
{
    /// <summary>
    /// 是否是有效参数
    /// </summary>
    bool isValid { get; }
    /// <summary>
    /// 资源包路径参数
    /// </summary>
    IAssetBundleLoadPathParameter path { get; }
    /// <summary>
    /// 输入参数
    /// </summary>
    IAssetBundleInputParameter inputParameter { get; }
}

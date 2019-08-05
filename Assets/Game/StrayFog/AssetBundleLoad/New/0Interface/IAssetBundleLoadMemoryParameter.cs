/// <summary>
/// 资源内存加载参数
/// </summary>
public interface IAssetBundleLoadMemoryParameter
{
    /// <summary>
    /// 资源包路径参数
    /// </summary>
    IAssetBundleLoadPathParameter path { get; }
    /// <summary>
    /// 输入参数
    /// </summary>
    IAssetBundleInputParameter inputParameter { get; }
    /// <summary>
    /// 结果回调
    /// </summary>
    AssetBundleResultEventHandler resultCallback { get; }
    /// <summary>
    /// 进度回调
    /// </summary>
    AssetBundleProgressEventHandler progressCallback { get; }
}

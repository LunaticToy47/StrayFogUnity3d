/// <summary>
/// 资源输出参数
/// </summary>
public interface IAssetBundleOutputParameter
{
    /// <summary>
    /// 结果回调
    /// </summary>
    AssetBundleResultEventHandler resultCallback { get; }
    /// <summary>
    /// 进度回调
    /// </summary>
    AssetBundleProgressEventHandler progressCallback { get; }
}

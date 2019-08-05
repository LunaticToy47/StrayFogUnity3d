/// <summary>
/// 资源输出参数
/// </summary>
public class AssetBundleOutputParameter : IAssetBundleOutputParameter
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_resultCallback">结果回调</param>
    /// <param name="_progressCallback">进度回调</param>
    public AssetBundleOutputParameter(AssetBundleResultEventHandler _resultCallback, AssetBundleProgressEventHandler _progressCallback)
    {
        resultCallback = _resultCallback;
        progressCallback = _progressCallback;
    }
    /// <summary>
    /// 结果回调
    /// </summary>
    public AssetBundleResultEventHandler resultCallback { get; private set; }
    /// <summary>
    /// 进度回调
    /// </summary>
    public AssetBundleProgressEventHandler progressCallback { get; private set; }
}

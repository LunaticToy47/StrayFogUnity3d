/// <summary>
/// 资源加载组件参数
/// </summary>
public class AssetBundleLoaderParameter
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_assetDiskMaping">磁盘映射</param>
    /// <param name="_onResultCallback">结果回调</param>
    /// <param name="_onProgressCallback">进度回调</param>
    /// <param name="_onErrorCallback">错误回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public AssetBundleLoaderParameter(XLS_Config_View_AssetDiskMaping _assetDiskMaping,
        AssetResultCallbackEventHandle _onResultCallback,
        AssetProgressCallbackEventHandle _onProgressCallback,
        AssetErrorCallbackEventHandle _onErrorCallback,
        params object[] _extraParameter)
    {
        assetDiskMaping = _assetDiskMaping;
        resultCallback = _onResultCallback;
        progressCallback = _onProgressCallback;
        errorCallback = _onErrorCallback;
        extraParameter = _extraParameter;
    }
    /// <summary>
    /// 磁盘映射
    /// </summary>
    public XLS_Config_View_AssetDiskMaping assetDiskMaping { get; private set; }
    /// <summary>
    /// 结果回调
    /// </summary>
    public AssetResultCallbackEventHandle resultCallback { get; private set; }
    /// <summary>
    /// 进度回调
    /// </summary>
    public AssetProgressCallbackEventHandle progressCallback { get; private set; }
    /// <summary>
    /// 错误回调
    /// </summary>
    public AssetErrorCallbackEventHandle errorCallback { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParameter { get; private set; }
}

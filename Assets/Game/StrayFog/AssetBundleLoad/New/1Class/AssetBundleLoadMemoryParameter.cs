/// <summary>
/// 资源内存加载参数
/// </summary>
public class AssetBundleLoadMemoryParameter: IAssetBundleLoadMemoryParameter
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_inputParameter">输入参数</param>
    /// <param name="_path">资源路径</param>
    /// <param name="_resultCallback">结果回调</param>
    /// <param name="_progressCallback">进度回调</param>
    public AssetBundleLoadMemoryParameter(
        IAssetBundleInputParameter _inputParameter,
        IAssetBundleLoadPathParameter _path, 
        AssetBundleResultEventHandler _resultCallback,
        AssetBundleProgressEventHandler _progressCallback
        )
    {
        path = _path;
        inputParameter = _inputParameter;
        resultCallback = _resultCallback;
        progressCallback = _progressCallback;
        errorCallback = _errorCallback;        
    }
    /// <summary>
    /// 资源包路径参数
    /// </summary>
    public IAssetBundleLoadPathParameter path { get; private set; }
    /// <summary>
    /// 输入参数
    /// </summary>
    public IAssetBundleInputParameter inputParameter { get; private set; }
    /// <summary>
    /// 结果回调
    /// </summary>
    public AssetBundleResultEventHandler resultCallback { get; private set; }
    /// <summary>
    /// 进度回调
    /// </summary>
    public AssetBundleProgressEventHandler progressCallback { get; private set; }
}
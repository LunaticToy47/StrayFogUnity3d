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
    public AssetBundleLoadMemoryParameter(IAssetBundleInputParameter _inputParameter,
        IAssetBundleLoadPathParameter _path)
    {
        path = _path;
        isValid = _inputParameter.config != null && _path != null;
    }

    /// <summary>
    /// 是否是有效参数
    /// </summary>
    public bool isValid { get; private set; }
    /// <summary>
    /// 资源包路径参数
    /// </summary>
    public IAssetBundleLoadPathParameter path { get; private set; }
    /// <summary>
    /// 输入参数
    /// </summary>
    public IAssetBundleInputParameter inputParameter { get; private set; }
}
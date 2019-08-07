using System.IO;
/// <summary>
/// 资源文件参数
/// </summary>
public class AssetBundleFileParameter: IAssetBundleFileParameter
{
    /// <summary>
    /// 资源ID
    /// </summary>
    public int assetBundleId { get; private set; }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string assetBundleName { get; private set; }
    /// <summary>
    /// 资源路径
    /// </summary>
    public string assetBundlePath { get; private set; }    
    /// <summary>
    /// 是否是内部资源
    /// </summary>
    public bool isInternal { get; private set; }
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_assetBundleName">资源包名称</param>
    public AssetBundleFileParameter(string _assetBundleName)
    {
        isInternal = StrayFogGamePools.setting.isInternal;
        if (isInternal)
        {
            assetBundleId = _assetBundleName.UniqueHashCode();
            assetBundleName = _assetBundleName;
            assetBundlePath = _assetBundleName.TransPathSeparatorCharToUnityChar();
        }
        else
        {
            assetBundleId = _assetBundleName.UniqueHashCode();
            assetBundleName = _assetBundleName;
            assetBundlePath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, _assetBundleName).TransPathSeparatorCharToUnityChar();
        }        
        
    }
}
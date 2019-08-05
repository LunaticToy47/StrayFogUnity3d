using System.IO;
/// <summary>
/// 资源文件参数
/// </summary>
public class AssetBundleFileParameter
{
    /// <summary>
    /// 资源ID
    /// </summary>
    public int assetId { get; private set; }

    /// <summary>
    /// 资源路径
    /// </summary>
    public string assetPath { get; private set; }

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
        assetId = _assetBundleName.UniqueHashCode();
        assetPath = Path.Combine(StrayFogGamePools.setting.assetBundleRoot, _assetBundleName).TransPathSeparatorCharToUnityChar();
        isInternal = StrayFogGamePools.setting.isInternal;
    }
}
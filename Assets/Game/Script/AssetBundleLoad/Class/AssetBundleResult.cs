using System.IO;
/// <summary>
/// AssetBundle结果
/// </summary>
public class AssetBundleResult
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_assetDiskMaping">资源磁盘映射</param>
    /// <param name="_instantiate">实例化函数</param>
    /// <param name="_extraParameter">额外参数</param>
    public AssetBundleResult(View_AssetDiskMaping _assetDiskMaping,
        System.Func<View_AssetDiskMaping, System.Type, UnityEngine.Object> _instantiate,
        object[] _extraParameter)
    {
        assetDiskMaping = _assetDiskMaping;
        mInstantiate = _instantiate;
        extraParameter = _extraParameter;
        assetName = Path.GetFileNameWithoutExtension(_assetDiskMaping.fileName);
    }
    /// <summary>
    /// 资源名称
    /// </summary>
    public string assetName { get; private set; }
    /// <summary>
    /// 资源磁盘映射
    /// </summary>
    public View_AssetDiskMaping assetDiskMaping { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParameter { get; private set; }
    /// <summary>
    /// 实例化
    /// </summary>
    System.Func<View_AssetDiskMaping, System.Type, UnityEngine.Object> mInstantiate;
    /// <summary>
    /// 实例化对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <returns>对象</returns>
    public T Instantiate<T>() where T : UnityEngine.Object
    {
        return (T)mInstantiate(assetDiskMaping, typeof(T));
    }
}

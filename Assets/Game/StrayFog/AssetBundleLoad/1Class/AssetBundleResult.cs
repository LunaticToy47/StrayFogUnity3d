using UnityEngine;
/// <summary>
/// 资源结果
/// </summary>
public class AssetBundleResult : IAssetBundleResult
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_input">输入</param>
    /// <param name="_extraParemeter">额外参数</param>
    /// <param name="_asset">资源</param>
    public AssetBundleResult(IAssetBundleInput _input, object[] _extraParemeter, Object _asset)
    {
        input = _input;
        extraParemeter = _extraParemeter;
        asset = _asset;
    }
    /// <summary>
    /// 输入
    /// </summary>
    public IAssetBundleInput input { get; private set; }
    /// <summary>
    /// 额外参数
    /// </summary>
    public object[] extraParemeter { get; private set; }
    /// <summary>
    /// 资源
    /// </summary>
    public Object asset { get; private set; }
}

using UnityEngine;
/// <summary>
/// 资源结果
/// </summary>
public interface IAssetBundleResult
{
    /// <summary>
    /// 输入
    /// </summary>
    IAssetBundleInput input { get; }
    /// <summary>
    /// 额外参数
    /// </summary>
    object[] extraParemeter { get; }
    /// <summary>
    /// 资源
    /// </summary>
    Object asset { get; }
}

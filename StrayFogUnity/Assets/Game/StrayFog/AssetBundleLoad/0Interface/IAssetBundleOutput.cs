using UnityEngine;
/// <summary>
/// 资源输出
/// </summary>
public interface IAssetBundleOutput
{
    /// <summary>
    /// 输入
    /// </summary>
    IAssetBundleInput input { get; }
    /// <summary>
    /// 实例化指定类型对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    void Instantiate<T>(AssetBundleInstantiateEventHandler _callback, params object[] _extraParameter) where T : Object;
    /// <summary>
    /// 实例化指定类型对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_defaultSelfActive">默认激活状态</param>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    void Instantiate<T>(bool _defaultSelfActive,AssetBundleInstantiateEventHandler _callback, params object[] _extraParameter) where T : Object;
}

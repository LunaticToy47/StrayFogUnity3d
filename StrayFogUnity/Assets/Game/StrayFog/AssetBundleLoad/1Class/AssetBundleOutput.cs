using System;
/// <summary>
/// 资源输出
/// </summary>
public class AssetBundleOutput : IAssetBundleOutput
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_input">输入</param>
    public AssetBundleOutput(IAssetBundleInput _input)
    {
        input = _input;
    }

    /// <summary>
    /// 输入
    /// </summary>
    public IAssetBundleInput input { get; private set; }

    /// <summary>
    /// 实例化请求事件
    /// </summary>
    public event Action<bool, IAssetBundleInput, Action<IAssetBundleResult>, object[], Type> OnInstantiate;

    /// <summary>
    /// 实例化指定类型对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void Instantiate<T>(Action<IAssetBundleResult> _callback, params object[] _extraParameter) where T : UnityEngine.Object
    {
        Instantiate<T>(true, _callback, _extraParameter);
    }
    /// <summary>
    /// 实例化指定类型对象
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    /// <param name="_defaultSelfActive">默认激活状态</param>
    /// <param name="_callback">回调</param>
    /// <param name="_extraParameter">额外参数</param>
    public void Instantiate<T>(bool _defaultSelfActive, Action<IAssetBundleResult> _callback, params object[] _extraParameter) where T : UnityEngine.Object
    {
        OnInstantiate?.Invoke(_defaultSelfActive, input, _callback, _extraParameter, typeof(T));
    }
}

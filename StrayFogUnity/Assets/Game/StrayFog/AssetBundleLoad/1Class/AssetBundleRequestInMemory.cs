using System;
/// <summary>
/// 资源请求加载到内存
/// </summary>
public class AssetBundleRequestInMemory : IAssetBundleRequestInMemory
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="_input">输入</param>
    /// <param name="_outputEvent">输出事件</param>
    /// <param name="_progressEvent">进度事件</param>
    public AssetBundleRequestInMemory(IAssetBundleInput _input,
        Action<IAssetBundleOutput> _outputEvent,
        Action<float, IAssetBundleInput> _progressEvent)
    {
        input = _input;
        outputEvent = _outputEvent;
        progressEvent = _progressEvent;
    }

    /// <summary>
    /// 输入
    /// </summary>
    public IAssetBundleInput input { get; private set; }
    /// <summary>
    /// 输出事件
    /// </summary>
    public Action<IAssetBundleOutput> outputEvent { get; private set; }
    /// <summary>
    /// 进度事件
    /// </summary>
    public Action<float, IAssetBundleInput> progressEvent { get; private set; }
}
/// <summary>
/// 资源输出事件句柄
/// </summary>
/// <param name="_output">输出</param>
public delegate void AssetBundleOutputEventHandler(IAssetBundleOutput _output);
/// <summary>
/// 资源进度事件句柄
/// </summary>
/// <param name="_progress">进度</param>
/// <param name="_input">输入</param>
public delegate void AssetBundleProgressEventHandler(float _progress,IAssetBundleInput _input);
/// <summary>
/// 资源实例化事件句柄
/// </summary>
/// <param name="_result">结果</param>
public delegate void AssetBundleInstantiateEventHandler(IAssetBundleResult _result);
/// <summary>
/// 资源输出请求实例化事件句柄
/// </summary>
/// <param name="_defaultSelfActive">默认激活状态</param>
/// <param name="_input">输入</param>
/// <param name="_callback">回调</param>
/// <param name="_extraParameter">额外参数</param>
/// <param name="_type">资源类型</param>
public delegate void AssetBundleOutputRequestInstantiateEventHandler(bool _defaultSelfActive,IAssetBundleInput _input, AssetBundleInstantiateEventHandler _callback, object[] _extraParameter,System.Type _type);
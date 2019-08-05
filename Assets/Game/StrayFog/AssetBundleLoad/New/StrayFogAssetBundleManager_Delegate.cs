/// <summary>
/// 资源结果事件句柄
/// </summary>
/// <param name="_result">结果</param>
public delegate void AssetBundleResultEventHandler(IAssetBundleResult _result);
/// <summary>
/// 资源进度事件句柄
/// </summary>
/// <param name="_progress">进度</param>
/// <param name="_inputParameter">输入参数</param>
public delegate void AssetBundleProgressEventHandler(float _progress, IAssetBundleInputParameter _inputParameter);
/// <summary>
/// 资源管理器【回调与输出】
/// </summary>
public partial class StrayFogNewAssetBundleManager
{

}

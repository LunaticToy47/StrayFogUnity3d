/// <summary>
/// 资源输入参数
/// </summary>
public interface IAssetBundleInputParameter
{
    /// <summary>
    /// 磁盘配置
    /// </summary>
    XLS_Config_View_AssetDiskMaping config { get; }

    /// <summary>
    /// 额外参数
    /// </summary>
    object[] extraParameter { get; }
}

using System.Text;
/// <summary>
/// StrayFogSetting
/// </summary>
public abstract class StrayFogSetting : AbsSingleScriptableObject<StrayFogSetting>
{
    #region Output
    /// <summary>
    /// Output
    /// </summary>
    /// <returns>ToString</returns>
    public string Output()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(string.Format("platform=>{0}", platform));
        sb.AppendLine(string.Format("assetBundleRoot=>{0}", assetBundleRoot));
        sb.AppendLine(string.Format("streamingAssetsRoot=>{0}", streamingAssetsRoot));
        sb.AppendLine(string.Format("manifestPath=>{0}", manifestPath));
        sb.AppendLine(string.Format("wwwPrefix=>{0}", wwwPrefix));
        return sb.ToString();
    }
    #endregion

    #region platform 运行平台
    /// <summary>
    /// 运行平台
    /// </summary>
    public abstract string platform { get; }
    #endregion

    #region assetBundleRoot 资源包根路径
    /// <summary>
    /// 资源包根路径
    /// </summary>
    public abstract string assetBundleRoot { get; }
    #endregion

    #region streamingAssetsRoot streamingAssets根目录
    /// <summary>
    /// streamingAssets根目录
    /// </summary>
    public abstract string streamingAssetsRoot { get; }
    #endregion

    #region manifestPath Manifest文件路径
    /// <summary>
    /// Manifest文件路径
    /// </summary>
    public abstract string manifestPath { get; }
    #endregion

    #region wwwPrefix WWW前缀
    /// <summary>
    /// WWW前缀
    /// </summary>
    public abstract string wwwPrefix { get; }
    #endregion

    #region assetBundleDbName 资源包数据库名称
    /// <summary>
    /// 资源包数据库名称
    /// </summary>
    public abstract string assetBundleDbName { get; }
    #endregion

    #region dbSource 数据库资源文件路径
    /// <summary>
    /// 数据库资源文件路径
    /// </summary>
    public abstract string dbSource { get; }
    #endregion

    #region dbConnectionString 数据库连接字符串
    /// <summary>
    /// 数据库连接字符串
    /// </summary>
    public abstract string dbConnectionString { get; }
    #endregion

    #region isInternal 是否是内部资源加载
    /// <summary>
    /// 是否是内部资源加载
    /// </summary>
    public abstract bool isInternal { get; }
    #endregion
}
